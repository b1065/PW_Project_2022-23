using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Chazan.GamesCatalog.INTERFACES;
using Chazan.GamesCatalog.CORE;

namespace Chazan.GamesCatalog.UI.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private IGame _game;
        public IGame Game
        {
            get => _game;
        }
        public GameViewModel(IGame game)
        {
            _game = game;
        }
        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get => _game.Name;
            set
            {
                _game.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }
        [Required(ErrorMessage = "Producer is required")]
        public IProducer Producer
        {
            get => _game.Producer;
            set
            {
                _game.Producer = value;
                Validate();
                OnPropertyChanged("Producer");
            }
        }
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 500, ErrorMessage = "Price must be between 0 and 500")]
        public double Price
        {
            get => _game.Price;
            set
            {
                _game.Price = value;
                Validate();
                OnPropertyChanged("Price");
            }
        }
        public GameType Type
        {
            get => _game.Type;
            set
            {
                _game.Type = value;
                Validate();
                OnPropertyChanged("Type");
            }
        }
        public void Validate()
        {
            var valContext = new ValidationContext(this, null, null);
            var valResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, valContext, valResults, true);
            foreach (var x in _errors.ToList())
            {
                if (valResults.All(r => r.MemberNames.All(m => m != x.Key)))
                {
                    _errors.Remove(x.Key);
                    OnErrorChanged(x.Key);
                }
            }
            var query = from f1 in valResults
                        from f2 in f1.MemberNames
                        group f1 by f2 into g
                        select g;
            foreach (var x in query)
            {
                var messages = x.Select(r => r.ErrorMessage).ToList();
                if (_errors.ContainsKey(x.Key))
                {
                    _errors.Remove(x.Key);
                }
                _errors.Add(x.Key, messages);
                OnErrorChanged(x.Key);
            }
        }
    }
}

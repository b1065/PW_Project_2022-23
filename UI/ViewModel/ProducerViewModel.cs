using Chazan.GamesCatalog.INTERFACES;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chazan.GamesCatalog.UI.ViewModel
{
    public class ProducerViewModel : ViewModelBase
    {
        private IProducer _producer;
        public IProducer Producer
        {
            get => _producer;
        }
        public ProducerViewModel(IProducer producer)
        {
            _producer = producer;
        }
        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }
        [Required(ErrorMessage = "Country of producer is required")]
        public string Country
        {
            get => _producer.Country;
            set
            {
                _producer.Country = value;
                Validate();
                OnPropertyChanged("Country");
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

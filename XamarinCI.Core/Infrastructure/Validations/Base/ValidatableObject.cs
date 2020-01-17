using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinCI.Core.Infrastructure.Validations.Base
{
    public sealed class ValidatableObject<T> : IValidity, IDisposable, INotifyPropertyChanged
    {
        private readonly bool _autoValidate;
        private bool _disposed = false;
        private readonly ObservableCollection<IValidationRule<T>> _rules;
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:XamarinCI.Core.Infrastructure.Validations.Base.ValidatableObject`1"/> class.
        /// </summary>
        /// <param name="autoValidate">Set to <c>true</c> to make it validate automatic, no need more handles on UI </param>
        public ValidatableObject(bool autoValidate = false)
        {
            _autoValidate = autoValidate;
            IsValid = true;
            Errors = new List<string>();
            _rules = new ObservableCollection<IValidationRule<T>>();
            if (_autoValidate)
                _rules.CollectionChanged += OnRulesCollectionChanged;
        }
        ~ValidatableObject()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_disposed)
                return;
            if (_autoValidate)
                _rules.CollectionChanged -= OnRulesCollectionChanged;
            _disposed = true;
        }

        private void OnRulesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Validate();
        }

        /// <summary>
        /// Get all errors message of this instance (from last validations)
        /// </summary>
        /// <value>The errors.</value>
        public IReadOnlyList<string> Errors { get; private set; }

        private T _value;

        /// <summary>
        /// Main value of your wrapped property
        /// </summary>
        /// <value>The value.</value>
        public T Value
        {
            get => _value; set
            {
                if (Equals(value, _value))
                    return;
                _value = value;
                if (_autoValidate)
                    Validate();
                OnPropertyChanged();
            }
        }
        private bool _isValid;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsValid
        {
            get => _isValid; private set
            {
                if (Equals(value, _isValid))
                    return;
                _isValid = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Validate this instance.
        /// </summary>
        /// <returns>The validate.</returns>
        public bool Validate()
        {
            Errors = _rules.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage).ToList();
            IsValid = !Errors.Any();
            OnPropertyChanged(nameof(Errors));
            return this.IsValid;
        }

        public void AddRules(params IValidationRule<T>[] rules)
        {
            if (rules == null || !rules.Any() || rules.Any(r => r == null))
                throw new ArgumentNullException(nameof(rules));

            foreach (var rule in rules)
                _rules.Add(rule);
        }

        public void ClearRules()
        {
            _rules.Clear();
        }

        public IValidationRule<T> GetRule(int index)
        {
            return _rules[index];
        }

        public IReadOnlyList<IValidationRule<T>> GetAllRules()
        {
            return _rules;
        }
    }
}

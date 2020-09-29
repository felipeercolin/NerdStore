namespace NerdStore.Vendas.Application.Validations
{
    public static class FluentValitionMessages
    {
        public static string Required => "O campo {PropertyName} precisa ser fornecido";
        public static string MinMaxLenght => "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";
        public static string ValueGreaterThan => "O campo {PropertyName} precisa ser maior que {ComparisonValue}";
        public static string ValueGreaterThanOrEqualTo => "O campo {PropertyName} precisa ser maior ou igual a {ComparisonValue}";
        public static string ValueLessThan => "O campo {PropertyName} precisa ser menor que {ComparisonValue}";
        public static string ValueLessThanOrEqualTo => "O campo {PropertyName} precisa ser menor ou igual a {ComparisonValue}";
        public static string DifferentThanZero => "O campo {PropertyName} precisar ser Diferente de 0";
        public static string InclusiveBetween => "O campo {PropertyName} precisa estar entre {From} e {To}";
        public static string InvalidCnpjCpf => "O {PropertyName} fornecido é inválido";
        public static string InvalidLengthCnpjCpf => "O campo {PropertyName} precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}";
        public static string MatchesOnlyNumbers => "O campo {PropertyName} deve conter somente numeros";
        public static string NotEqual => "O campo {PropertyName} deve ser diferente de {ComparisonValue}";
        public static string NotExists => "O campo {PropertyName} não Existe";

        public static string RequiredSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                        ? Required
                  : ChangingPropertyNameToDisplayName(Required, displayName);
        }

        public static string MinMaxLenghtSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? MinMaxLenght
                : ChangingPropertyNameToDisplayName(MinMaxLenght, displayName);
        }

        public static string ValueGreaterThanSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? ValueGreaterThan
                : ChangingPropertyNameToDisplayName(ValueGreaterThan, displayName);
        }

        public static string ValueGreaterThanOrEqualToSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? ValueGreaterThanOrEqualTo
                : ChangingPropertyNameToDisplayName(ValueGreaterThanOrEqualTo, displayName);
        }

        public static string ValueLessThanSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? ValueLessThan
                : ChangingPropertyNameToDisplayName(ValueLessThan, displayName);
        }

        public static string ValueLessThanOrEqualToSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? ValueLessThanOrEqualTo
                : ChangingPropertyNameToDisplayName(ValueLessThanOrEqualTo, displayName);
        }

        public static string DifferentThanZeroSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? DifferentThanZero
                : ChangingPropertyNameToDisplayName(DifferentThanZero, displayName);
        }
        
        public static string InclusiveBetweenSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? InclusiveBetween
                : ChangingPropertyNameToDisplayName(InclusiveBetween, displayName);
        }

        public static string InvalidCnpjCpfSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? InvalidCnpjCpf
                : ChangingPropertyNameToDisplayName(InvalidCnpjCpf, displayName);
        }

        public static string InvalidLengthCnpjCpfSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? InvalidLengthCnpjCpf
                : ChangingPropertyNameToDisplayName(InvalidLengthCnpjCpf, displayName);
        }

        public static string MatchesOnlyNumbersSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? MatchesOnlyNumbers
                : ChangingPropertyNameToDisplayName(MatchesOnlyNumbers, displayName);
        }

        public static string NotEqualSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? NotEqual
                : ChangingPropertyNameToDisplayName(NotEqual, displayName);
        }

        public static string NotExistsSetPropertyName(string displayName)
        {
            return string.IsNullOrEmpty(displayName)
                ? NotExists
                : ChangingPropertyNameToDisplayName(NotExists, displayName);
        }

        public static string ChangingPropertyNameToDisplayName(string message, string displayName)
        {
            return message.Replace("{PropertyName}", displayName);
        }
    }
}
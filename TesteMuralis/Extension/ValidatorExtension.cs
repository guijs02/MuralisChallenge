namespace TesteMuralis.WebApi.Extension
{
    public static class ValidatorExtension
    {
        public static object FormatValidationErrors(this FluentValidation.Results.ValidationResult result) =>
            result.Errors.Select(e => new
            {
                campo = e.PropertyName,
                erro = e.ErrorMessage
            });
    }
}

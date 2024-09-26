using TaskManager.Enums;

namespace TaskManager.Extensions
{
    public static class ErrorMessageTypeExtensions
    {
        public static string GetMessage(this ErrorMessageType errorMessageType)
        {
            return errorMessageType switch
            {
                ErrorMessageType.GenericError => "Sistem kaynaklı bir sorun",
                ErrorMessageType.InvalidToken => "JWT Token yanlış",
                ErrorMessageType.EmailAlreadyExists => "Bu Email adresi zaten kayıtlı!",
                ErrorMessageType.InvalidCredentials => "Kullanıcı adı ya da şifreniz yanlış", 
                _ => "Bilinmeyen bir hata oluştu"
            };
        }
    }
}
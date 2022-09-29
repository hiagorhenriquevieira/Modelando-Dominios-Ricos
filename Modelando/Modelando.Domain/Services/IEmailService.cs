namespace Modelando.Domain.Services
{
    public interface IEmailService
    {
        void EnviarEmail(string para, string email, string assunto, string corpoDaMensagem);
    }
}

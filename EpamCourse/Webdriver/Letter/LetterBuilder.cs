namespace EpamCourse.Webdriver.Letter
{
    public class LetterBuilder
    {
        private LetterObject _letter;

        public LetterBuilder()
        {
            _letter = new LetterObject();
        }

        public LetterBuilder SetSubject(string subject)
        {
            _letter.Subject = subject;
            return this;
        }

        public LetterBuilder SetRecipient(string recipient)
        {
            _letter.Recipient = recipient;
            return this;
        }

        public LetterBuilder SetMessage(string message)
        {
            _letter.Message = message;
            return this;
        }

        public LetterObject Build()
        {
            return _letter;
        }
    }
}

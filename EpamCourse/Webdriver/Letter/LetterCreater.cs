using EpamCourse.Helpers;

namespace EpamCourse.Webdriver.Letter
{
    public class LetterCreater
    {
        private LetterObject Letter { get; set; }
        public LetterCreater(string recepient)
        {
            Letter = new LetterBuilder()
                .SetRecipient(recepient)
                .SetSubject(new RandomString().GetRandomString())
                .SetMessage(new RandomString().GetRandomString())
                .Build();
        }

        public LetterObject GetLetter()
        {
            return Letter;
        }
    }
}

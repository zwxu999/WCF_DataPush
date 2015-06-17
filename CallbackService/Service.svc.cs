using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Timers;

namespace CallbackService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service : IService
    {
        public Book[] books;
        public static System.Timers.Timer Timer;
        public static IServiceCallback CallBack;

        //public IServiceCallback CallBack
        //{
        //    get { return OperationContext.Current.GetCallbackChannel<IServiceCallback>(); }
        //}

        public void Seed()
        {
            CallBack = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            books = new Book[]
            {
                new Book()
                {
                    Id = 1,
                    Title = "WOLVERINE MAX",
                    Author = "MARVEL",
                    Description =
                        "Крушение самолета обрывает жизни всех пассажиров... кроме одного. Главный герой очнулся в токийской больнице и теперь он главный подозреваемый. Что же произошло той ночью? Несчастный случай или запланированое преступление? Кто стоит за всем этим? Ответы на эти вопросы и предстоит узнать Джону Гранту или быть может...Логану?",
                    ImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Imgs\wolverine.jpg")
                },
                new Book()
                {
                    Id = 2,
                    Title = "Harbinger ",
                    Author = "Valiant",
                    Description =
                        "Подросток Питер Станчек безработный бездомный, и... однажды к нему приходит Тойо Харада и предлагает вступить в проект <Предвестник>, в котором набирают людей с необычным потенциалом, чтобы изменить ход человеческой истории. Тойо Харада богатый бизнес-магнат, уважаемый филантроп и самый мощный предвестник - или он так думал?",
                    ImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Imgs\harbinger.jpg")
                },
                new Book()
                {
                    Id = 3,
                    Title = "Ghosted",
                    Author = "Skybound",
                    Description =
                        "Если смешать в одном комиксе «Одиннадцать друзей Оушена», «Сияние», «Экзорциста» и «Бешеных псов», вы получите «Призраков» Джошуа Уильямсона, одну из лучших серий 2013-го года, стабильно собирающую хвалебные оды от критиков и читателей, изначально задуманную как мини, но продленную до онгоинга. Если вы до сих пор думаете, читать или не читать, то у вас нет души. ",
                    ImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Imgs\ghosted.jpg")
                },
                new Book()
                {
                    Id = 4,
                    Title = "SPAWN",
                    Author = "Image Comics",
                    Description =
                        "Спаун (англ. Spawn — «Исчадие») — персонаж комиксов, придуманный Тоддом Макфарлейном. В основном Спаун появляется в одноименной серии комиксов, которую издают Image Comics.Эл Симмонс, агент ЦРУ, убитый собственным начальником за то, что стал свидетелем его коррумпированности, попал в ад. Чтобы в последний раз увидеть свою жену, он заключил сделку с демоном Мэлболгией и стал немертвым «Хеллспауном»",
                    ImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Imgs\spawn.jpg")
                }
            };

            CallBack.SendContext(books);
        }

        public void StartSpam(int interval)
        {
            Timer = new System.Timers.Timer(interval);
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
        }

        public void StopSpam()
        {
            Timer.Enabled = false;
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random rand = new Random();
            CallBack.SendOffer(books[rand.Next(0, books.Count())]);
        }

        //public string ImageToString(string path)
        //{

        //    if (path == null)

        //        throw new ArgumentNullException("path");

        //    Image im = Image.FromFile(path);

        //    MemoryStream ms = new MemoryStream();

        //    im.Save(ms, im.RawFormat);

        //    byte[] array = ms.ToArray();

        //    return Convert.ToBase64String(array);
        //}  
    }
}

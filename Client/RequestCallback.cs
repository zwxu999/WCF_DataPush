using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.MyCallbackServiceReference;

namespace Client
{
    public class RequestCallback : IServiceCallback
    {
        private Book[] _Books;

        public Book[] Books
        {
            get { return _Books; }
            set
            {
                _Books = value;
            }
        }
        //обратный вызов клиентской формы с сервисным сообщением
        public void SendOffer(Book offer)
        {
            Book offerBook = offer;
            Popup pp = new Popup(offerBook);
            if (!pp.Modal)
            {               
                pp.ShowDialog();
            }
        }
        //обратный вызов передачи данных с сервиса клиенту
        public void SendContext(Book[] context)
        {
            Books = context;
        }
    }
}

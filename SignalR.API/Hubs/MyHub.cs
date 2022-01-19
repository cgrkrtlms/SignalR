using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.API.Hubs
{
    public class MyHub:Hub
    {
        // Clientlar SendMessage methoduna istek yapacaklar ve name isminde bir data gönderecekler.Daha sonra bu method çalıştığı zaman Clientlar üzerindeki "ReceiveMessage" a bir bildiri gidecek.(Clientlar üzerindeki ReceiveMessage methodu çalışsın, çalışırken name parametresinde gönderilen data da gitsin.).Eğer Clientlar "ReceiveMessage" methoduna subcribe olmuşsa method çalışacak,eğer subcribe olmamışsa mesajları server'dan almayacak. 

        public static List<string> Names { get; set; } = new List<string>();

        public async Task SendName(string name)
        {
            Names.Add(name);

            // All : Bu Hub'a bağlı olan tüm clientlara bildiri gönderir.Clientlardaki şu method çalışsın diye.
            await Clients.All.SendAsync("ReceiveName", name);
        }

        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveNames",Names);
        }

    }
}

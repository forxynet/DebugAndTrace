#define DEBUG // for debugging
//or
#define TRACE // for tracing

using System;
using System.IO;
using System.Diagnostics;

public class TraceListenerExample {
    public static void Main() {
        //Bir ürün hakkında bilgi içerecek şekilde değişkenlerini başlatmak için aşağıdaki bildirim deyimleri Main yöntemine ekleyin:
        string sProdName = "Widget";
        int iUnitQty = 100;
        double dUnitCost = 1.03;
        //WriteLine yönteminin ilk giriş parametresi olarak sınıf üreten iletiyi belirtin. Output penceresi görünür olduğundan emin olmak için CTRL +ALT + O tuş bileşimine basın.
        Debug.WriteLine("Debug Information-Product Starting ");
        //Okunabilirlik için çıktı penceresinde sonraki iletileri girintilemek için Girinti yöntemini kullanın:
        Debug.Indent();
        //Seçili değişkenlerinin içeriğini görüntülemek için WriteLine yöntemi aşağıdaki gibi kullanın:
        Debug.WriteLine("The product name is " + sProdName);
        Debug.WriteLine("The available units on hand are" + iUnitQty.ToString());
        Debug.WriteLine("The per unit cost is " + dUnitCost.ToString());
        //WriteLine yöntemi, isim uzayı ve sınıf adı varolan bir nesne için görüntülemek için de kullanabilirsiniz. Örneğin, aşağıdaki kod çıktı penceresinde System.Xml.XmlDocument ad boşluğunu görüntüler:
        System.Xml.XmlDocument oxml = new System.Xml.XmlDocument();
        Debug.WriteLine(oxml);
        //Çıkış düzenlemek için bir kategori olarak isteğe bağlı, ikinci giriş parametresi WriteLine yönteminin içerebilir.Kategori belirtirseniz, çıktı penceresinde ileti biçimi olan "Kategori: ileti." Örneğin aşağıdaki kodun ilk satırı görüntüler "alanı: Ürün adı pencere öğesi olan" Output penceresinde:
        Debug.WriteLine("The product name is " + sProdName, "Field");
        Debug.WriteLine("The units on hand are" + iUnitQty, "Field");
        Debug.WriteLine("The per unit cost is" + dUnitCost.ToString(), "Field");
        Debug.WriteLine("Total Cost is  " + (iUnitQty * dUnitCost), "Calc");
        //Output penceresi, yalnızca hata ayıklama sınıfının WriteLineIf yöntemi kullanılarak belirtilen bir koşul doğru olarak değerlendirilirse, iletileri görüntüleyebilirsiniz.Değerlendirilmek üzere koşul WriteLineIf yönteminin ilk giriş parametresidir. WriteLineIf ' in ikinci parametresi yalnızca ilk parametresinde koşul doğru olarak değerlendirilirse, görüntülenen bir iletidir.
        Debug.WriteLineIf(iUnitQty > 50, "This message WILL appear");
        Debug.WriteLineIf(iUnitQty < 50, "This message will NOT appear");
        //Hata ayıklama sınıfı yöntemine çağrıdan kullanabilir, böylece yalnızca belirtilen bir koşul yanlış olarak değerlendirilirse çıktı penceresinde ileti görüntülenir:
        Debug.Assert(dUnitCost > 1, "Message will NOT appear");
        Debug.Assert(dUnitCost < 1, "Message will appear since dUnitcost < 1 is false");
        //Konsol penceresi(tr1) ve(tr2) çıktı.txt adlı bir metin dosyası için olmalıdır nesneleri oluşturmak ve her nesne için Hata ayıklama dinleyicileri koleksiyonu ekleyin:
        TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
       // Debug.Listeners.Add(tr1);

        TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText("Output.txt"));
       // Debug.Listeners.Add(tr2);
        //Okunabilirlik için izleyen iletiler için Girintiyi kaldırmak için Unindent yöntemini kullanın.
        //Hata ayıklama sınıfı oluşturur. Okuyucu Girinti ve Unindent yöntemleri kullandığınızda, çıktı grubu olarak ayırt edebilirsiniz.
        Debug.Unindent();
        Debug.WriteLine("Debug Information-Product Ending");
        // Her dinleyici nesnesi tüm çıktı aldığından emin olmak için hata ayıklama sınıfı arabellekleri için reçeteye göre sarf yöntemini çağırın:
        Debug.Flush();


        Trace.WriteLine("Trace Information-Product Starting ");
        Trace.Indent();

        Trace.WriteLine("The product name is " + sProdName);
        Trace.WriteLine("The product name is" + sProdName, "Field");
        Trace.WriteLineIf(iUnitQty > 50, "This message WILL appear");
        Trace.Assert(dUnitCost > 1, "Message will NOT appear");

        Trace.Unindent();
        Trace.WriteLine("Trace Information-Product Ending");

        Trace.Flush();

        Console.ReadLine();
    }
}
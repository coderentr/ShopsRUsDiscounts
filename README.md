# ShopRUsDiscounts


Selamlar;

ShopRUsDiscounts, perakende satışlarının müşteri tiplerine göre indirimlerinin hesaplanması ve faturaların oluşturulması için geliştirilmiş bir temel projedir.
Bu projeyi kullanarak müşterilerinizin türüne göre otomatik olarak indirimler hesaplanabilir ve faturalar oluşturulabilir. 

## Özellikler

- Müşteri tiplerine göre indirim hesaplama
- MessageBroken ile asenkron fatura oluşturma
- Code First veritabanı mantığı ile MSSQL kullanımı
- Docker ile hızlı başlatma


## Teknolojiler ve Kütüphaneler

Projede kullanılan temel teknolojiler ve kütüphaneler:

- .NET Core 7
- RabbitMQ: Sipariş alındıktan sonra asenkron fatura oluşturmak için Mesaj kuyruğu sistemi için kullanılmıştır.
- Clean Architecture
- Strategy Design Pattern: Müşteri tiplerine göre indirim hesaplama işleminde kullanılmıştır.
- CQRS

## Kullanım Kılavuzu

Projeyi çalıştırmak ve kullanmak için aşağıdaki adımları izleyin:

1. **Gereksinimler**

   Projeyi çalıştırmak için aşağıdaki gereksinimlere sahip olmalısınız:
   - Docker yüklü olmalıdır.

2. **Projeyi Docker ile Çalıştırma**

   Projeyi Docker ile başlatmak için terminalde projenizin kök dizinine gidin ve şu komutu çalıştırın:

   ```bash
   docker-compose up


## Endpointler

### OrderController

#### CreateOrder Endpointi

- Bu endpoint, müşteri kimliği (`CustomerId`) ve sipariş fiyatı (`OrderPrice`) gibi temel bilgileri alarak, gerekli şartlara göre indirimleri hesaplar ve bu bilgileri fatura oluşturmak için ilgili kuyruğa gönderir.
Tüketici (consumer), bu kuyruğu dinler ve siparişin fatura bilgisini veritabanına kaydeder.


### InvoiceController

#### Get Endpointi

-  Bu endpoint, bir fatura numarası (`InvoiceNumber`) verildiğinde ilgili faturanın bilgilerini döndürür.
-  


 #### Test readme dosyasını okumak için [**tıklayın.**](https://github.com/coderentr/ShopsRUsDiscounts/blob/main/test/UnitTest.Application/TestReadme.md)


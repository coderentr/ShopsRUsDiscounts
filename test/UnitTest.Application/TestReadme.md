
# Test Ortamı

Projenin testleri NUnit çerçevesini kullanarak yazıldı. Ayrıca Moq kütüphanesi, sahte nesneleri oluşturmak ve test senaryolarını simüle etmek için kullanıldı.

## Nasıl Çalıştırılır

Bu ünite testlerini çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

1. Projeyi bilgisayarınıza klonlayın veya indirin.

2. Projeyi Visual Studio veya başka bir C# geliştirme ortamında açın.

3. Testlerinizi çalıştırmak için test projesini seçin.

4. Testlerinizi çalıştırmak için seçilen test projesini sağ tıklayın ve "Çalıştır" veya "Tüm Testleri Çalıştır" seçeneğini seçin.

5. Test sonuçlarını görüntüleyin. Her iki testin de başarılı bir şekilde geçip geçmediğini kontrol edin.

## Dikkat Edilmesi Gereken Noktalar

- Testlerin başarıyla geçmesi için bağımlılıkları doğru bir şekilde ayarlamak önemlidir. Bu nedenle Moq kütüphanesiyle sahte nesneleri ve bağımlılıkları uygun şekilde yapılandırmak önemlidir.

- İşlem başarılı veya başarısız olduğunda beklenen sonuçları kontrol etmek için `NUnit.Framework.Assert` kullanılır. Her iki testte de beklenen sonuçların doğru bir şekilde belirtilmesi gerekir.

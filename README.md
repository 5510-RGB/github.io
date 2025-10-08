# PolatPortfolio - Visual Studio ASP.NET Core MVC Starter

Bu proje Visual Studio ile açıp çalıştırabileceğin **ASP.NET Core MVC** örnek portfolyo uygulamasıdır.
- Tema: Dark
- Blog: Dinamik (örnek veri)
- CV: Web görüntüleme + PDF indirme (iText7 kullanılarak basit oluşturma)
- İletişim: SMTP (MailKit) ile gönderim. Varsayılan kullanıcı: mehmetmac49@gmail.com

## Nasıl çalıştırılır
1. Bu klasörü Visual Studio'da aç (PolatPortfolio.csproj dosyasını aç).  
2. `appsettings.json` içindeki `Smtp:Password` alanına Gmail uygulama şifreni gir.  
   - Gmail kullanıyorsan hesabına 2FA etkinleştirip **App Password** oluşturmalısın.
3. Paketleri restore et (Visual Studio otomatik yapar veya `dotnet restore` kullan).  
4. Projeyi çalıştır (F5).

## Notlar
- `appsettings.json` şu anda SMTP kullanıcı adı `mehmetmac49@gmail.com` olarak geliyor. Güvenlik nedeniyle parola boş bırakıldı; kendi uygulama şifreni gir.
- iText7 paketi basit PDF oluşturma için eklendi. Gelişmiş CV formatı istiyorsan ek düzenlemeler yaparım.

1) Projeyi çalıştırabilmek için caseAPI projesi içerisindeki appsettings.json dosyasındaki connectionstring özelliğini kendi veritabanı bilgilerinize göre güncellemeniz gerekmekte.

2) caseDal projesine sağ tıklayıp 'Open in Terminal' seçeneğine bastıktan sonra açılan terminal ekranına aşağıdaki kodları yazıp çalıştırmanız gerekmekte.
Bu sayede veritabanını kendisi oluşturacaktır.

=>dotnet ef migrations add InitialCreate --startup-project ../CaseAPI

=>dotnet ef database update  --startup-project ../CaseAPI

3) 
kullanıcı adı => aliiakcekoca@gmail.com 
şifre => qwerty12-
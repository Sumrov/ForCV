namespace EslOnline.Host.Views
{
    public static class ErrorPage
    {
        public static string GetHtmlCode(string error) => @"
<!DOCTYPE html>
<html>
<head>
    <title>Economic strategy of life ONLINE・Внутрення ошибка сервера</title>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap'>
    <style>
        body { background-color: #1e2223; display: flex; justify-content: center; align-items: center; height: 100vh; margin: 0; }
        .panel { background-color: #444653; padding: 10px 40px; text-align: center; border-radius: 10px; }
        .panel p { margin: 10px; color: #c1cdc7; font-size: 80px; font-weight: bold; font-family: Roboto, sans-serif; }
    </style>
</head>
<body>
    <div class='panel' id='copyPanel'><p id='copyText'>ERROR_VALUE</p></div>
</body>
</html>".Replace("ERROR_VALUE", error);
    }
}

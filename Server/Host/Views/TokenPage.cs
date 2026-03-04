namespace EslOnline.Host.Views
{
    public static class TokenPage
    {
        public static string GetHtmlCode(string token) => @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Economic Strategy Of Life ONLINE · Ваш ключ доступа</title>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap'>
    <style>
        body { background-color: #1e2223; display: flex; justify-content: center; align-items: center; height: 100vh; margin: 0; }
        .panel { background-color: #444653; padding: 10px 40px; text-align: center; border-radius: 15px; display: none; }
        .panel p { margin: 10px; color: #c1cdc7; font-size: 18px; font-weight: bold; font-family: Roboto, sans-serif; }
        button { padding: 10px 40px; background-color: #333541; color: #c1cdc7; font-size: 16px; font-weight: bold; border: none; border-radius: 15px; cursor: pointer; font-family: Roboto, sans-serif; }
    </style>
</head>
<body>
    <button id='copyButton' onclick='copyToClipboard()'>Получить ключ</button>
    <div class='panel' id='copyPanel'><p id='copyText'>Готово! Возвращайтесь в игру</p></div>
    <script>
        function copyToClipboard() {
            const value = 'TOKEN_VALUE';
            navigator.clipboard.writeText(value);
            document.getElementById('copyPanel').style.display = 'block';
            document.getElementById('copyButton').style.display = 'none';
        }
    </script>
</body>
</html>".Replace("TOKEN_VALUE", token);
    }
}

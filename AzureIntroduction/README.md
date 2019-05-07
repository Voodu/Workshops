# Microsoft Azure - Try it out!
Materials from talk about Microsoft Azure

## Sample applications

### **Static website**
Just upload website static files to Storage Account created on Azure. Do it by using [Microsoft Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)

### **Redirect**
Applications requires date adjustments to see it working. Proper (future) dates should be provided in `Redirect.Helpers.GetData()` method, lines 31, 35 and 39.
<br/>**Note!** Due to browser caching, the best way to test is by using incognito mode.

### **[Face API](https://docs.microsoft.com/en-us/azure/cognitive-services/face/quickstarts/csharp)**
You have to provide `subscriptionKey` (line 12) and service endpoint in `uriBase` to make the app work.
<br/>3 test images are provided. To use them after launching the app, type:
- `images/face1.jpg`
- `images/face2.jpg`
- `images/face3.jpg`



## Useful links:
- [Azure 4 students](https://azure.microsoft.com/en-us/free/students/)
- [Microsoft Learn](https://docs.microsoft.com/en-us/learn/)
- Intelligent Kiosk - [aplikacja](https://www.microsoft.com/en-us/p/intelligent-kiosk/9nblggh5qd84),  [source code](https://github.com/Microsoft/Cognitive-Samples-IntelligentKiosk)

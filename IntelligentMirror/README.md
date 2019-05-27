# Intelligent Mirror
## UWP CameraStarterKit sample combined with FaceAPI

### Workshop shows how to build an UWP application which uses camera for capturing photos and sends them to Face Service on Microsoft Azure cloud to get information about captured faces.

Launch the solution using `Samples/IntelligentMirror/cs/IntelligentMirror.sln`

*Code is based on [Microsoft UWP samples repository](https://github.com/Microsoft/Windows-universal-samples) and [Face API quickstart](https://docs.microsoft.com/en-us/azure/cognitive-services/face/quickstarts/csharp).* 
*<br>`Face.cs` file contents were generated using [json2csharp](http://json2csharp.com/) service.*

## Using the repository
Repository is build with *checkpoint* approach in mind. Various git tags allow jumping from one part of the project development phase to another.
<br>Each checkpoint has various `TODO` comments guiding how to develop the app further.

To check out on specific tag, use `git checkout tags/TAG_NAME`, ex. `git checkout tags/naming-controls`

Currently available tags (from nearly empty to almost working project):
- ui-setup
- naming-controls
- navigation
- passing-photo
- azure-request
- json-parsing
- hair-emotion
- multiple-faces

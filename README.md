# Gcp Storage Example
Example of Google Cloud Platform Storage Access from C# .Net

## First read the Google Cloud Authentication reference
* https://cloud.google.com/docs/authentication/getting-started

## Configuration
* Add two files to the 'GcpStorageExample.Settings' project
    * Add your key file to the 'storage-key' folder
    * Add a copy of the 'GlobalConstants' class and name it `GlobalConstants.partial.cs` 
        * In that new partial replace all the settings with one `public const string STORAGE_BUCKET_NAME = "your-bucket-name";`

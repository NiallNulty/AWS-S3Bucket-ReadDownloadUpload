using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AWSS3ReadDownloadUpload : MonoBehaviour
{
    //To access AWS Config file
    [SerializeField] private AWSConfig awsConfig;

    //This will display the text we read from S3
    [SerializeField] private InputField inputField;

    //Client for accessing S3 files
    private AmazonS3Client client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest1);

    //this is the name of the file
    //in a real life scenario should read string from an input instead 
    //of fixed string
    private string key = "TestFile.txt";

    public void ReadFromS3()
    {
        //Send request
        GetObjectRequest request = new GetObjectRequest();

        //Get bucket name from config
        request.BucketName = awsConfig.AWSS3BucketName;

        //The files key, its usually the file name
        request.Key = key;

        //Get response from S3
        GetObjectResponse response = client.GetObject(request);

        //Using streamreader to rest string from txt file
        StreamReader reader = new StreamReader(response.ResponseStream);
        string content = reader.ReadToEnd();

        //Populate input field
        inputField.text = content;
    }

    public void DownloadFromS3()
    {
        //Send request
        GetObjectRequest request = new GetObjectRequest();

        //Get bucket name from config
        request.BucketName = awsConfig.AWSS3BucketName;

        //The files key, its usually the file name
        request.Key = key;

        //Get response from S3
        GetObjectResponse assetResponse = client.GetObject(request);

        //Download file and save to resources folder
        assetResponse.WriteResponseStreamToFile(Application.dataPath + "/Resources/" + key);
    }
}

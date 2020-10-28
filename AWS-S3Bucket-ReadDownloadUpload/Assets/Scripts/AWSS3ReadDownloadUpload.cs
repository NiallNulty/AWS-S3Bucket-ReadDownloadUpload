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

    public void ReadFromS3()
    {
        //Semd request
        GetObjectRequest assetRequest = new GetObjectRequest();

        //Get bucket name from config
        assetRequest.BucketName = awsConfig.AWSS3BucketName;

        //The files key, its usually the file name
        assetRequest.Key = "TestFile.txt";

        //Get response from S3
        GetObjectResponse response = client.GetObject(assetRequest);

        //Using streamreader to rest string from txt file
        StreamReader reader = new StreamReader(response.ResponseStream);
        string content = reader.ReadToEnd();

        //Populate input field
        inputField.text = content;
    }
}

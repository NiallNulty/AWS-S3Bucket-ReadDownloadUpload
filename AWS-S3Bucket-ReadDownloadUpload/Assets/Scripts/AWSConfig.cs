using UnityEngine;

[CreateAssetMenu(fileName = "AWSConfig", menuName = "AWS/Create AWSConfig", order = 1)]
public class AWSConfig : ScriptableObject
{
    #region Properties
    public string AWSKey;
    public string AWSSecretKey;
    public string AWSS3BucketName;
    #endregion
}
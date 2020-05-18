using System;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        int key = 3;                                                        //key to crypting and decrypting
        public string Crypt(string message)
        {
            int ascii = 0;                                                  // variable utilized to see the character in decimal numbers see ascii http://www.asciitable.com/
            if (message == null)                                            //Null exception implementations
                throw new ArgumentNullException();
            char[] messagechar = (message.ToLower()).ToCharArray();         //separate the string in an array of char and put all letters in lower case
            int i = 0;                                                      //counter of the array
			string crypting = "";                                           //initialize the crypting
            foreach (char character in messagechar)
            {
                ascii = messagechar[i];     
                if (ascii >= 48 && ascii <=57)                              //number 0 =  48 ascii ... 9 =57 ascii
                    ascii = messagechar[i];
                else if (ascii == 32)                                       // space = 32 ascii
                    ascii = messagechar[i];
                else if (ascii < 97 || ascii > 122)                         //alphabet char a = 97 ascii ... z=122 ascii
                    throw new ArgumentOutOfRangeException();                //special character exception
                else
                {
                    if (messagechar[i] + key > 'z')                         //crypting
                        ascii =  messagechar[i] + key - ('z' - 'a' + 1);    //crypting
                    else
                        ascii = messagechar[i] + key;                       //crypting    
                }
                i++;                                    
                crypting += ((char)ascii).ToString();                       //appending char to string
            }
			return crypting;                                                //return the criptedmessage
        }

        public string Decrypt(string cryptedmessage)                        //The decrypting is very similar but the key has the opposite signal
        {
            int ascii = 0;
            if (cryptedmessage == null)
                throw new ArgumentNullException();

            char[] messagechar = (cryptedmessage.ToLower()).ToCharArray();
            int i = 0;
            string decrypting = null;
            foreach (char character in messagechar)
            {
                ascii = messagechar[i];
                if (ascii >= 48 && ascii <= 57)
                    ascii = messagechar[i];
                else if (ascii == 32)
                    ascii = messagechar[i];
                else if (ascii < 97 || ascii > 122)
                    throw new ArgumentOutOfRangeException();
                else
                {
                    if (messagechar[i] - key < 'a' - 0)
                        ascii = ('z' - 'a' +1) + messagechar[i] - key;
                    else
                        ascii = messagechar[i] - key;
                }
                i++;
                decrypting = decrypting + ((char)ascii).ToString();
            }
            return decrypting; 
        }
    }
}
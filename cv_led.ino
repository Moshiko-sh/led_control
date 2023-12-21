#include <LedControl.h>
int DIN = 11;
int CS =  10;
int CLK = 9;
LedControl lc=LedControl(DIN,CLK,CS,0);
// Set the incoming data to 10 data
String ab[8];
String data;
String sectionData;
int a;
int stringData;
byte Data[8];//=   {0x00,0xAA,0xAA,0xAA,0xAA,0xAA,0xAA,0xAA};
void setup()
{
  Serial.begin(9600);
  pinMode (13,OUTPUT);
  pinMode (12,OUTPUT);
  digitalWrite (13,HIGH);
  digitalWrite (12,LOW);
   
 lc.shutdown(0,false);       //The MAX72XX is in power-saving mode on startup
 lc.setIntensity(0,15);      // Set the brightness to maximum value
 lc.clearDisplay(0);         // and clear the display
  
}

void loop()
{
  
  while (Serial.available()>1)
  
   {
    data = Serial.readString();
    
    for (a = 0; a <data.length()-1 ; a++)
    {
     
      ab[a] = getData(data, '-', a);
       Data[a]=convertdata(ab[a]);
      lc.setRow(0,a,Data[a]);
     if (ab[a] != NULL)
     {
        
        Serial.print("Array ");
        Serial.print(a);
        Serial.print(" = ");
        Serial.println(ab[a]);
        if (a==7)
        break;
        //Data[a]=convertdata(ab[a]);
        //lc.setRow(0,a,Data[a]);
        

       }
       if (a==7)
        break;
    }
      if (a==7)
        break;
   }
     //printByte(Data);
  
  
    
}



byte convertdata( String str)
{
  byte conv =0x00;
  if (str == "00")
     return conv = 0x00;
  else if (str == "01")
    return conv = 0x01;
    else if (str == "02")
    return conv = 0x02;
    else if (str == "03")
    return conv = 0x03;
    else if (str == "04")
    return conv = 0x04;
    else if (str == "05")
    return conv = 0x05;
    else if (str == "06")
    return conv = 0x06;
    else if (str == "07")
    return conv = 0x07;
    else if (str == "08")
    return conv = 0x08;
    else if (str == "09")
    return conv = 0x09;
    else if (str == "0A")
    return conv = 0x0A;
    else if (str == "0B")
    return conv = 0x0B;
    else if (str == "0C")
    return conv = 0x0C;
    else if (str == "0D")
    return conv = 0x0D;
    else if (str == "0E")
    return conv = 0x0E;
    else if (str == "0F")
    return conv = 0x0F;

    else if (str == "10")
    return conv = 0x10;
    else if (str == "11")
    return conv = 0x11;
    else if (str == "12")
    return conv = 0x12;
    else if (str == "13")
    return conv = 0x13;
    else if (str == "14")
    return conv = 0x14;
    else if (str == "15")
    return conv = 0x15;
    else if (str == "16")
    return conv = 0x16;
    else if (str == "17")
    return conv = 0x17;
    else if (str == "18")
    return conv = 0x18;
    else if (str == "19")
    return conv = 0x19;
    else if (str == "1A")
    return conv = 0x1A;
    else if (str == "1B")
    return conv = 0x1B;
    else if (str == "1C")
    return conv = 0x1C;
    else if (str == "1D")
    return conv = 0x1D;
    else if (str == "1E")
    return conv = 0x1E;
    else if (str == "1F")
    return conv = 0x1F;


    else if (str == "20")
    return conv = 0x20;
    else if (str == "21")
    return conv = 0x21;
    else if (str == "22")
    return conv = 0x22;
    else if (str == "23")
    return conv = 0x23;
    else if (str == "24")
    return conv = 0x24;
    else if (str == "25")
    return conv = 0x25;
    else if (str == "26")
    return conv = 0x26;
    else if (str == "27")
    return conv = 0x27;
    else if (str == "28")
    return conv = 0x28;
    else if (str == "29")
    return conv = 0x29;
    else if (str == "2A")
    return conv = 0x2A;
    else if (str == "2B")
    return conv = 0x2B;
    else if (str == "2C")
    return conv = 0x2C;
    else if (str == "2D")
    return conv = 0x2D;
    else if (str == "2E")
    return conv = 0x2E;
    else if (str == "2F")
    return conv = 0x2F;


    else if (str == "30")
    return conv = 0x30;
    else if (str == "31")
    return conv = 0x31;
    else if (str == "32")
    return conv = 0x32;
    else if (str == "33")
    return conv = 0x33;
    else if (str == "34")
    return conv = 0x34;
    else if (str == "35")
    return conv = 0x35;
    else if (str == "36")
    return conv = 0x36;
    else if (str == "37")
    return conv = 0x37;
    else if (str == "38")
    return conv = 0x38;
    else if (str == "19")
    return conv = 0x19;
    else if (str == "3A")
    return conv = 0x3A;
    else if (str == "3B")
    return conv = 0x3B;
    else if (str == "3C")
    return conv = 0x3C;
    else if (str == "3D")
    return conv = 0x3D;
    else if (str == "3E")
    return conv = 0x3E;
    else if (str == "3F")
    return conv = 0x3F;

    else if (str == "40")
    return conv = 0x40;
    else if (str == "41")
    return conv = 0x41;
    else if (str == "42")
    return conv = 0x42;
    else if (str == "43")
    return conv = 0x43;
    else if (str == "44")
    return conv = 0x44;
    else if (str == "45")
    return conv = 0x45;
    else if (str == "46")
    return conv = 0x46;
    else if (str == "47")
    return conv = 0x47;
    else if (str == "48")
    return conv = 0x48;
    else if (str == "49")
    return conv = 0x49;
    else if (str == "4A")
    return conv = 0x4A;
    else if (str == "4B")
    return conv = 0x4B;
    else if (str == "4C")
    return conv = 0x4C;
    else if (str == "4D")
    return conv = 0x4D;
    else if (str == "4E")
    return conv = 0x4E;
    else if (str == "4F")
    return conv = 0x4F;


    else if (str == "50")
    return conv = 0x50;
    else if (str == "51")
    return conv = 0x51;
    else if (str == "52")
    return conv = 0x52;
    else if (str == "53")
    return conv = 0x53;
    else if (str == "54")
    return conv = 0x54;
    else if (str == "55")
    return conv = 0x55;
    else if (str == "56")
    return conv = 0x56;
    else if (str == "57")
    return conv = 0x57;
    else if (str == "58")
    return conv = 0x58;
    else if (str == "59")
    return conv = 0x59;
    else if (str == "5A")
    return conv = 0x5A;
    else if (str == "5B")
    return conv = 0x5B;
    else if (str == "5C")
    return conv = 0x5C;
    else if (str == "5D")
    return conv = 0x5D;
    else if (str == "5E")
    return conv = 0x5E;
    else if (str == "5F")
    return conv = 0x4F;

    else if (str == "60")
    return conv = 0x60;
    else if (str == "61")
    return conv = 0x61;
    else if (str == "62")
    return conv = 0x62;
    else if (str == "63")
    return conv = 0x63;
    else if (str == "64")
    return conv = 0x64;
    else if (str == "65")
    return conv = 0x65;
    else if (str == "66")
    return conv = 0x66;
    else if (str == "67")
    return conv = 0x67;
    else if (str == "68")
    return conv = 0x68;
    else if (str == "69")
    return conv = 0x69;
    else if (str == "6A")
    return conv = 0x6A;
    else if (str == "6B")
    return conv = 0x6B;
    else if (str == "6C")
    return conv = 0x6C;
    else if (str == "6D")
    return conv = 0x6D;
    else if (str == "6E")
    return conv = 0x6E;
    else if (str == "6F")
    return conv = 0x6F;

    else if (str == "70")
    return conv = 0x70;
    else if (str == "71")
    return conv = 0x71;
    else if (str == "72")
    return conv = 0x72;
    else if (str == "73")
    return conv = 0x73;
    else if (str == "74")
    return conv = 0x74;
    else if (str == "75")
    return conv = 0x75;
    else if (str == "76")
    return conv = 0x76;
    else if (str == "77")
    return conv = 0x77;
    else if (str == "78")
    return conv = 0x78;
    else if (str == "79")
    return conv = 0x79;
    else if (str == "7A")
    return conv = 0x7A;
    else if (str == "7B")
    return conv = 0x7B;
    else if (str == "7C")
    return conv = 0x7C;
    else if (str == "7D")
    return conv = 0x7D;
    else if (str == "7E")
    return conv = 0x7E;
    else if (str == "7F")
    return conv = 0x7F;


    else if (str == "80")
    return conv = 0x80;
    else if (str == "81")
    return conv = 0x81;
    else if (str == "82")
    return conv = 0x82;
    else if (str == "83")
    return conv = 0x83;
    else if (str == "84")
    return conv = 0x84;
    else if (str == "85")
    return conv = 0x85;
    else if (str == "86")
    return conv = 0x86;
    else if (str == "87")
    return conv = 0x87;
    else if (str == "88")
    return conv = 0x88;
    else if (str == "89")
    return conv = 0x89;
    else if (str == "8A")
    return conv = 0x8A;
    else if (str == "8B")
    return conv = 0x8B;
    else if (str == "8C")
    return conv = 0x8C;
    else if (str == "8D")
    return conv = 0x8D;
    else if (str == "8E")
    return conv = 0x8E;
    else if (str == "8F")
    return conv = 0x8F;

    else if (str == "90")
    return conv = 0x90;
    else if (str == "91")
    return conv = 0x91;
    else if (str == "92")
    return conv = 0x92;
    else if (str == "93")
    return conv = 0x93;
    else if (str == "94")
    return conv = 0x94;
    else if (str == "95")
    return conv = 0x95;
    else if (str == "96")
    return conv = 0x96;
    else if (str == "97")
    return conv = 0x97;
    else if (str == "98")
    return conv = 0x98;
    else if (str == "99")
    return conv = 0x99;
    else if (str == "9A")
    return conv = 0x9A;
    else if (str == "9B")
    return conv = 0x9B;
    else if (str == "9C")
    return conv = 0x9C;
    else if (str == "9D")
    return conv = 0x9D;
    else if (str == "9E")
    return conv = 0x9E;
    else if (str == "9F")
    return conv = 0x9F;


   else if (str == "A0")
    return conv = 0xA0;
    else if (str == "A1")
    return conv = 0xA1;
    else if (str == "A2")
    return conv = 0xA2;
    else if (str == "A3")
    return conv = 0xA3;
    else if (str == "A4")
    return conv = 0xA4;
    else if (str == "A5")
    return conv = 0xA5;
    else if (str == "A6")
    return conv = 0xA6;
    else if (str == "A7")
    return conv = 0xA7;
    else if (str == "A8")
    return conv = 0xA8;
    else if (str == "A9")
    return conv = 0xA9;
    else if (str == "AA")
    return conv = 0xAA;
    else if (str == "AB")
    return conv = 0xAB;
    else if (str == "AC")
    return conv = 0xAC;
    else if (str == "AD")
    return conv = 0xAD;
    else if (str == "AE")
    return conv = 0xAE;
    else if (str == "AF")
    return conv = 0xAF;

    else if (str == "B0")
    return conv = 0xB0;
    else if (str == "B1")
    return conv = 0xB1;
    else if (str == "B2")
    return conv = 0xB2;
    else if (str == "B3")
    return conv = 0xB3;
    else if (str == "B4")
    return conv = 0xB4;
    else if (str == "B5")
    return conv = 0xB5;
    else if (str == "B6")
    return conv = 0xB6;
    else if (str == "B7")
    return conv = 0xB7;
    else if (str == "B8")
    return conv = 0xB8;
    else if (str == "B9")
    return conv = 0xB9;
    else if (str == "BA")
    return conv = 0xBA;
    else if (str == "BB")
    return conv = 0xBB;
    else if (str == "BC")
    return conv = 0xBC;
    else if (str == "BD")
    return conv = 0xBD;
    else if (str == "BE")
    return conv = 0xBE;
    else if (str == "BF")
    return conv = 0x4F;

    else if (str == "C0")
    return conv = 0xC0;
    else if (str == "C1")
    return conv = 0xC1;
    else if (str == "C2")
    return conv = 0xC2;
    else if (str == "C3")
    return conv = 0xC3;
    else if (str == "C4")
    return conv = 0xC4;
    else if (str == "C5")
    return conv = 0xC5;
    else if (str == "C6")
    return conv = 0xC6;
    else if (str == "C7")
    return conv = 0xC7;
    else if (str == "C8")
    return conv = 0xC8;
    else if (str == "C9")
    return conv = 0xC9;
    else if (str == "CA")
    return conv = 0xCA;
    else if (str == "CB")
    return conv = 0xCB;
    else if (str == "CC")
    return conv = 0x4C;
    else if (str == "4D")
    return conv = 0xCD;
    else if (str == "CE")
    return conv = 0xCE;
    else if (str == "CF")
    return conv = 0xCF;

    else if (str == "D0")
    return conv = 0xD0;
    else if (str == "D1")
    return conv = 0xD1;
    else if (str == "D2")
    return conv = 0xD2;
    else if (str == "D3")
    return conv = 0xD3;
    else if (str == "D4")
    return conv = 0xD4;
    else if (str == "D5")
    return conv = 0xD5;
    else if (str == "D6")
    return conv = 0xD6;
    else if (str == "D7")
    return conv = 0xD7;
    else if (str == "D8")
    return conv = 0xD8;
    else if (str == "D9")
    return conv = 0xD9;
    else if (str == "DA")
    return conv = 0xDA;
    else if (str == "DB")
    return conv = 0xDB;
    else if (str == "DC")
    return conv = 0xDC;
    else if (str == "DD")
    return conv = 0xDD;
    else if (str == "DE")
    return conv = 0xDE;
    else if (str == "DF")
    return conv = 0xDF;

    else if (str == "E0")
    return conv = 0xE0;
    else if (str == "E1")
    return conv = 0xE1;
    else if (str == "E2")
    return conv = 0xE2;
    else if (str == "E3")
    return conv = 0xE3;
    else if (str == "E4")
    return conv = 0xE4;
    else if (str == "E5")
    return conv = 0xE5;
    else if (str == "E6")
    return conv = 0xE6;
    else if (str == "E7")
    return conv = 0xE7;
    else if (str == "E8")
    return conv = 0xE8;
    else if (str == "E9")
    return conv = 0xE9;
    else if (str == "EA")
    return conv = 0xEA;
    else if (str == "EB")
    return conv = 0xEB;
    else if (str == "EC")
    return conv = 0xEC;
    else if (str == "ED")
    return conv = 0xED;
    else if (str == "EE")
    return conv = 0xEE;
    else if (str == "EF")
    return conv = 0xEF;

    else if (str == "F0")
    return conv = 0xF0;
    else if (str == "F1")
    return conv = 0xF1;
    else if (str == "F2")
    return conv = 0xF2;
    else if (str == "F3")
    return conv = 0xF3;
    else if (str == "F4")
    return conv = 0xF4;
    else if (str == "F5")
    return conv = 0xF5;
    else if (str == "F6")
    return conv = 0xF6;
    else if (str == "F7")
    return conv = 0xF7;
    else if (str == "F8")
    return conv = 0xF8;
    else if (str == "F9")
    return conv = 0xF9;
    else if (str == "FA")
    return conv = 0xFA;
    else if (str == "FB")
    return conv = 0xFB;
    else if (str == "FC")
    return conv = 0xFC;
    else if (str == "FD")
    return conv = 0xFD;
    else if (str == "FE")
    return conv = 0xFE;
    else if (str == "FF")
    return conv = 0xFF;
    
   else
     return conv = 0x00;
}



void printByte(byte character [])
{
  int i = 0;
  for(i=0;i<8;i++)
  {
    lc.setRow(0,i,character[i]);
  }
}



  
String getData(String data, char delimiter, int sequence)
{
  stringData = 0;
  sectionData = "";

  for (int i = 0; i < data.length() - 1; i++)
  {

    if (data[i] == delimiter)
    {
      stringData++;
    }

    else if (stringData == sequence)
    {
      sectionData.concat(data[i]);
    }

    else if (stringData > sequence)
    {
      return sectionData;
      break;
    }
  }

  return sectionData;
}

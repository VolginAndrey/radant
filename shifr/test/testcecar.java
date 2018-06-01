
import java.util.Scanner;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author KL
 */
public class testcecar {
    public void cecar() 
    {
        char[] alfos = null;
        char[] alfnew;
        alfnew = null;
        String alfitog = null;
        int k,j=0;
        Scanner text_vhod = new Scanner(System.in);
        char[] ar_text_vhod;
        ar_text_vhod = text_vhod.next().toCharArray();
        Scanner ks = new Scanner(System.in);
        int n=ar_text_vhod.length;
        k = ks.nextInt();
        int al=32;
        for(int i = 'а';i<='я';i++)
        {
            alfos[i-1071]=(char) i;
        }
        for(int i=0;i<=al;i++)
        {
            
            if(i+k<al)
            {
                alfnew[i]=alfos[i+k];
            }
            if(i+k>=al && j<k)
            {
                alfnew[i]=alfos[j];
                j++;
            }
            System.out.print((char)alfnew[i]);
        }
        for(int i=0;i<=al;i++)
        {
            for(int pos=0;pos<=n;pos++)
            {
                if(alfos[i]==ar_text_vhod[pos])
                {
                    alfitog=alfitog+alfnew[i];
                }
            }
        }
        System.out.print(alfitog);
    }
}

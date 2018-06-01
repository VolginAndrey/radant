/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package shifrhight.Models;

/**
 *
 * @author KL
 */
public class BlockEncryptor {
    private static void aswap(char[] pa, int i, int j) {
        char k = pa[i];
        pa[i] = pa[j];
        pa[j] = k;
    }

    private static String arraout(char[] pa, int i) {
        String s = "";

        for (char a : pa) {
            s += a;
        }

        s = s.substring(0, s.length());
        return s;

    }
    private static String prmt(char[] pa, int i, int k, int ik) {

        for (int j = i; j < pa.length; j++) {
            ik++;

            aswap(pa, i, j);
            if (ik == k) {

                break;
            }
            prmt(pa, i + 1, k, ik);
            aswap(pa, i, j);
        }
        String textInput = arraout(pa, i);
        return textInput;
    }
    public String encrypt(String textInputClient,Integer key,Integer kBlock){
        String textOutPut = "";
        String text;
        String textInput = textInputClient;
        Integer k = key;
        Integer nblock = kBlock;
        int raz=textInput.length();
        if (textInput.length()%nblock==0){
            for (int i = 0, j = nblock; i < textInput.length(); i = i + nblock, j = j + nblock) {
                text = textInput.substring(i, j);
                char[] pa = text.toCharArray();
                textOutPut = textOutPut + prmt(pa, 0, k, 0).toString();
            }
        }
        else{
            while(raz>=0){
            raz=raz-nblock;
            }
            for(int i=0;i>raz;i--){
                textInput=textInput+'#';
            }  
            for (int i = 0, j = nblock; i < textInput.length(); i = i + nblock, j = j + nblock) {
                text = textInput.substring(i, j);
                char[] pa = text.toCharArray();
                textOutPut = textOutPut + prmt(pa, 0, k, 0).toString();
            }
        }
        return textOutPut;
    }

    public String encrypt(String text, String key, String kBLock) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}

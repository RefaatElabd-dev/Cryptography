namespace SubstitutionCipher.Constants
{
    internal class Constants
    {
        public static Dictionary<char, char> PreparedKey = new()
        {
            { 'A', 'X' },
            { 'B', 'T' },
            { 'C', 'W' },
            { 'D', 'D' },
            { 'E', 'V' },
            { 'F', 'Q' },
            { 'G', 'Z' },
            { 'H', 'L' },
            { 'I', 'S' },
            { 'J', 'O' },
            { 'K', 'N' },
            { 'L', 'B' },
            { 'M', 'A' },
            { 'N', 'U' },
            { 'O', 'G' },
            { 'P', 'H' },
            { 'Q', 'K' },
            { 'R', 'E' },
            { 'S', 'P' },
            { 'T', 'Y' },
            { 'U', 'R' },
            { 'V', 'C' },
            { 'W', 'I' },
            { 'X', 'F' },
            { 'Y', 'M' },
            { 'Z', 'J' },
        };
        public const string Message = "In cryptography, frequency analysis is a critical method. It involves examining the frequency of letters or groups of letters in encrypted text. The most common letter in English is 'E', followed by 'T', 'A', 'O', 'I', and 'N'. By comparing the frequency of letters in ciphertext to these common frequencies, one can deduce the likely substitutions. This approach is effective against simple substitution ciphers, where each letter in the plaintext is replaced by a corresponding letter in the ciphertext. The technique exploits the predictable frequency of letters, helping cryptanalysts to break the code successfully.";
        public const string cipher = "WK VUTSBJOUMSPT, XURFNRKVT MKMHTIWI WI M VUWBWVMH YRBPJD. WB WKEJHERI RAMYWKWKO BPR XURFNRKVT JX HRBBRUI JU OUJNSI JX HRBBRUI WK RKVUTSBRD BRAB. BPR YJIB VJYYJK HRBBRU WK RKOHWIP WI 'R', XJHHJCRD LT 'B', 'M', 'J', 'W', MKD 'K'. LT VJYSMUWKO BPR XURFNRKVT JX HRBBRUI WK VWSPRUBRAB BJ BPRIR VJYYJK XURFNRKVWRI, JKR VMK DRDNVR BPR HWQRHT INLIBWBNBWJKI. BPWI MSSUJMVP WI RXXRVBWER MOMWKIB IWYSHR INLIBWBNBWJK VWSPRUI, CPRUR RMVP HRBBRU WK BPR SHMWKBRAB WI URSHMVRD LT M VJUURISJKDWKO HRBBRU WK BPR VWSPRUBRAB. BPR BRVPKWFNR RASHJWBI BPR SURDWVBMLHR XURFNRKVT JX HRBBRUI, PRHSWKO VUTSBMKMHTIBI BJ LURMQ BPR VJDR INVVRIIXNHHT.";
    }
}

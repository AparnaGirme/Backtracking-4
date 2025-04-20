public class Solution {
    List<string> result;
    List<List<char>> blocks;
    public string[] Expand(string s) {
        if(string.IsNullOrEmpty(s)){
            return new string[0];
        }

        blocks = new List<List<char>>();
        result = new List<string>();
        int i = 0;
        while(i< s.Length){
            char c = s[i];
            List<char> block = new List<char>();
            if(c == '{'){
                i++;
                while(s[i] != '}'){
                    if(s[i] != ','){
                        block.Add(s[i]);
                    }
                    i++;
                }
            }
            else{
                block.Add(c);
            }
            block.Sort();
            blocks.Add(block);
            i++;
        }

        // blocks.Sort((a, b) => {
        //     int minLength = Math.Min(a.Count, b.Count);
        //     for(int i = 0; i < minLength; i++){
        //         if(a[i] != b[i]){
        //             return a[i].CompareTo(b[i]);
        //         }
        //     }
        //     return a.Count.CompareTo(b.Count);
        // });

        Backtrack(0, new StringBuilder());
        return result.ToArray();
    }

    public void Backtrack(int index, StringBuilder sb){
        // base
        if(index == blocks.Count){
            result.Add(sb.ToString());
            return;
        }

        //logic
        List<char> li = blocks[index];
        for(int i = 0; i< li.Count; i++){
            // action
            int length = sb.Length;
            sb.Append(li[i]);

            // recurse
            Backtrack(index + 1, sb);

            //backtrack
            sb.Remove(length, 1);
        }
    }
}
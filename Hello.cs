namespace Welcome;

public static class HelloUser
{
    public static void Hello()
    {
        string hello = @"
    :::       :::     :::     :::        :::    ::: :::::::::: ::::::::: 
   :+:       :+:   :+: :+:   :+:        :+:   :+:  :+:        :+:    :+: 
  +:+       +:+  +:+   +:+  +:+        +:+  +:+   +:+        +:+    +:+  
 +#+  +:+  +#+ +#++:++#++: +#+        +#++:++    +#++:++#   +#++:++#:    
+#+ +#+#+ +#+ +#+     +#+ +#+        +#+  +#+   +#+        +#+    +#+    
#+#+# #+#+#  #+#     #+# #+#        #+#   #+#  #+#        #+#    #+#     
###   ###   ###     ### ########## ###    ### ########## ###    ###      
";
        for (int i = 0; i < hello.Length; i++)
        {
            Console.Write(hello[i]);
            Thread.Sleep(2);
        }
        Console.WriteLine();
    }
}
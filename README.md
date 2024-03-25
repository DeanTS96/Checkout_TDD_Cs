Welcome to my checkout Program. 

To ensure this works on your device, please make sure you have the microsoft SDK 
And the C# language installed upto version 8.0.103

Next open the root of the project, this being the directory containing these files and directories
 
 ```
 -\ .vscode
 -\ Checkout
 -\ CheckoutLibrary
 -\ CheckoutLibraryTests
 -\ Utils
 README.md
 TDD_Cs_CheckoutApp.sln

```

 Then run the command 
  ``` dotnet build ```

  Once successfuly run 
   ``` dotnet run --project Checkout/Checkout.csproj ```

The program should now run and you should see the welcome display in the terminal, prompting you to scan your items.

```

* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*                                                                 *
*                      Welcome To Checkout!                       *
*                                                                 *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *


Please scan your items by entering a single lettter... 
and then pressing enter (enter only single capital letters)

When you are finished scanning your items, just press Enter.

```

And that's all!

Scan your items and then checkout!
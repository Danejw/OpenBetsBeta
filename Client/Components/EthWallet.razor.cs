using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Web3;
using WalletConnectSharp.NEthereum;
using WalletConnectSharp.Core.Models;
using WalletConnectSharp.Desktop;

namespace OpenBetsBeta.Client.Components;
partial class EthWallet
{
   private WalletConnect connectedWallet;
   private bool walletConnected = false;

   public async Task ConnectWalletViaWalletConnect()
   {
      var metadata = new ClientMeta()
      {
         Description = "This is a test of the Nethereum.WalletConnect feature",
         Icons = new[] { "" },
         Name = "WalletConnect Test",
         URL = "https://www.Google.com"
      };
      

      connectedWallet = new WalletConnect(metadata);
      //Console.WriteLine(connectedWallet.URI);

      await connectedWallet.Connect();
      walletConnected = true;

      //Console.WriteLine(connectedWallet.Accounts[0]);
      //Console.WriteLine(connectedWallet.ChainId);

      var web3 = new Web3(connectedWallet.CreateProvider(new Uri("https://ropsten.infura.io/v3/05fed8e2281c4582b923ebeca90e628f")));

   }

   private void ToggleConnect()
   {
      if (walletConnected) walletConnected = false;
      else walletConnected = true;
   }

   private void aldkfj()
   {

   }
   

}

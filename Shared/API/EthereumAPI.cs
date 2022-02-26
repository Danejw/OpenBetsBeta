using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Web3;
using WalletConnectSharp.NEthereum;
using WalletConnectSharp.Core.Models;
using WalletConnectSharp.Desktop;

namespace OpenBetsBeta.Shared.API;
public class EthereumAPI
{
   private Task walletConnectData;
   public async Task ConnectWallet()
   {
      var metadata = new ClientMeta()
      {
         Description = "This is a test of the Nethereum.WalletConnect feature",
         Icons = new[] { "" },
         Name = "WalletConnect Test",
         URL = "https://app.warriders.com"
      };
      

      var walletConnect = new WalletConnect(metadata);
      Console.WriteLine(walletConnect.URI);

      await walletConnect.Connect();

      Console.WriteLine(walletConnect.Accounts[0]);
      Console.WriteLine(walletConnect.ChainId);

      var web3 = new Web3(walletConnect.CreateProvider(new Uri("https://ropsten.infura.io/v3/05fed8e2281c4582b923ebeca90e628f")));

   }

}

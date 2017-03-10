using System;
using System.Collections.Generic;
using JF.Services;

namespace JF.Communication.Net.Ftp
{
	internal class FtpCommandLoader : CommandLoaderBase
	{
		protected override bool OnLoad(CommandTreeNode node)
		{
			node.Children.Add(new FtpAborCommand());
			node.Children.Add(new FtpAlloCommand());
			node.Children.Add(new FtpAppeCommand());
			node.Children.Add(new FtpCdupCommand());
			node.Children.Add(new FtpCwdCommand());
			node.Children.Add(new FtpDeleCommand());
			node.Children.Add(new FtpFeatCommand());
			node.Children.Add(new FtpHelpCommand());
			node.Children.Add(new FtpListCommand());
			node.Children.Add(new FtpMdtmCommand());
			node.Children.Add(new FtpMfmtCommand());
			node.Children.Add(new FtpMkdCommand());
			node.Children.Add(new FtpMlsdCommand());
			node.Children.Add(new FtpMlstCommand());
			node.Children.Add(new FtpNoopCommand());
			node.Children.Add(new FtpOptsCommand());
			node.Children.Add(new FtpPassCommand());
			node.Children.Add(new FtpPasvCommand());
			node.Children.Add(new FtpPortCommand());
			node.Children.Add(new FtpPwdCommand());
			node.Children.Add(new FtpQuitCommand());
			node.Children.Add(new FtpRestCommand());
			node.Children.Add(new FtpRetrCommand());
			node.Children.Add(new FtpRmdCommand());
			node.Children.Add(new FtpRnfrCommand());
			node.Children.Add(new FtpRntoCommand());
			node.Children.Add(new FtpSizeCommand());
			node.Children.Add(new FtpStorCommand());
			node.Children.Add(new FtpSystCommand());
			node.Children.Add(new FtpTypeCommand());
			node.Children.Add(new FtpUserCommand());

			//返回加载成功
			return true;
		}
	}
}
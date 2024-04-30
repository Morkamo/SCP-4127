using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP_4127
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public Item4127 scp_4127 { get; set; } = new();

        [Description("Translate settigns: \nEagle fell out [Lucky]")]
        public string case1_lucky_eagle { get; set; } = "CASE 1 (Lucky Eagle)";
        public string case2_lucky_eagle { get; set; } = "CASE 2 (Lucky Eagle)";
        public string case3_lucky_eagle { get; set; } = "CASE 3 (Lucky Eagle)";
        public string case4_lucky_eagle { get; set; } = "CASE 4 (Lucky Eagle)";
        public string case5_lucky_eagle { get; set; } = "CASE 5 (Lucky Eagle)";
        public string case6_lucky_eagle { get; set; } = "CASE 6 (Lucky Eagle)";
        public string case7_lucky_eagle { get; set; } = "CASE 7 (Lucky Eagle)";
        
        [Description("Eagle fell out [unLucky]")]
        public string case1_unlucky_eagle { get; set; } = "CASE 1 (unLucky Eagle)";
        public string case2_unlucky_eagle { get; set; } = "CASE 2 (unLucky Eagle)";
        public string case3_unlucky_eagle { get; set; } = "CASE 3 (unLucky Eagle)";
        public string case4_unlucky_eagle { get; set; } = "CASE 4 (unLucky Eagle)";
        public string case5_unlucky_eagle { get; set; } = "CASE 5 (unLucky Eagle)";
        public string case6_unlucky_eagle { get; set; } = "CASE 6 (unLucky Eagle)";
        public string case7_unlucky_eagle { get; set; } = "CASE 7 (unLucky Eagle)";
        
        [Description("Tails fell out [Lucky]")]
        public string case1_lucky_tails { get; set; } = "CASE 1 (Lucky tails)";
        public string case2_lucky_tails { get; set; } = "CASE 2 (Lucky tails)";
        public string case3_lucky_tails { get; set; } = "CASE 3 (Lucky tails)";
        public string case4_lucky_tails { get; set; } = "CASE 4 (Lucky tails)";
        public string case5_lucky_tails { get; set; } = "CASE 5 (Lucky tails)";
        public string case6_lucky_tails { get; set; } = "CASE 6 (Lucky tails)";
        public string case7_lucky_tails { get; set; } = "CASE 7 (Lucky tails)";
        public string case8_lucky_tails { get; set; } = "CASE 8 (Lucky tails)";
        
        [Description("Tails fell out [unLucky]")]
        public string case1_unlucky_tails { get; set; } = "CASE 1 (unLucky tails)";
        public string case2_unlucky_tails { get; set; } = "CASE 2 (unLucky tails)";
        public string case3_unlucky_tails { get; set; } = "CASE 3 (unLucky tails)";
        public string case4_unlucky_tails { get; set; } = "CASE 4 (unLucky tails)";
        public string case5_unlucky_tails { get; set; } = "CASE 5 (unLucky tails)";
        public string case6_unlucky_tails { get; set; } = "CASE 6 (unLucky tails)";
        public string case7_unlucky_tails { get; set; } = "CASE 7 (unLucky tails)";
        public string case8_unlucky_tails { get; set; } = "CASE 8 (unLucky tails)";
    }
}
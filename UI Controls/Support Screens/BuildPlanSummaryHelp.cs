using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class BuildPlanSummaryHelp : Objects.FormBase
    {
        public BuildPlanSummaryHelp()
        {
            InitializeComponent();
            LoadText();
        }

        private void LoadText()
        {
            StringBuilder helpBuilder = new StringBuilder();

            helpBuilder.AppendLine("The Build Plan control is an in-depth build guide that allows you to customize " +
                "everything about the build process. There is a lot of information, but this is everything you need" +
                " to determine how much an item costs from start to finish.");

            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("To get started with a new build, click \"New Build Plan\" at the top. " +
                "Give the Build Plan a name like \"Gyros\", then select the item you wish to build. " +
                "You can type in the drop down as if it were a text field and it will filter the list.");

            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("Once you select an item, it will load the defaults you have configured in the" +
                " \"Configure Defaults\" screen, load all of the market information for the build plan, including" +
                " the input costs, output prices, job costs, and price history. Once everything is loaded, you can" +
                " move onto modifying the build plan by selecting if you want to build or react the inputs, the system" +
                " and structure you are building the items in, and setting custom prices.");

            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("The first step in modifying the build plan is setting the blueprint and reaction settings." +
                " On the tab \"BP & Reaction Settings\", set all of the blueprints ME and TE values, the max amount of runs" +
                ", and whether you want to make the item or not. You can do this by clicking " +
                "\"Set All Blueprint Info\" or by clicking on the blueprint name in the treeview. Do the same thing for the reactions." +
                " The only difference is that reactions don't have ME/TE values.");

            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("Once you've configured your BP's and reactions, go to the \"System\\Structure\\Order Type\" " +
                "tab and confirm the choices for Manufacturing info, reaction info, order types, and skills. " +
                "All of these settings affect the total cost to make the item. For example, building something in Jita is " +
                "massively more expensive than building something in a system 5 jumps away. There are multiple reasons. " +
                "The player owned structures like Raitaru's, Tatara's, etc. have a bonus to material input amounts inherent " +
                "to the structure themselves. You can also install rigs to further reduce costs. Even if you're building in an NPC" +
                " station in another system, the System Cost Index for that activity will be a lot lower than in Jita. Jita's system " +
                "cost index usually hovers around 20% and can dramatically slash profits. Every setting on this tab affects the outcome.");

            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("Once you're done configuring the first two tabs, you can move to the \"Materials & Prices\" tab. " +
                "This tab is where you can set custom prices for both the final product (you're setting price per item) and all of the calculated" +
                " inputs. Please note that this list will change depending on the BP & Reaction settings from step 1. If you choose to " +
                "make the fuel blocks instead of buy them, the fuel blocks will be removed from the list and the inputs for those fuel " +
                "blocks will be added. There is also an option to exclude tax on inputs and outcome in case you're buying from someone via direct trade" +
                " or selling to someone via private contract. i.e. Buying and selling Titans, Supercarriers, etc.");

            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("Notes on values.");
            helpBuilder.AppendLine("1.) Waste/Leftover materials - When you choose to make an item via reactions or BP's, sometimes you have" +
                " leftover materials because the blueprint makes too many. Fuel blocks are a common instance. The BP's always make 40 blocks " +
                "per run. If you're doing reactions and only need 35 fuel blocks, you have 5 leftover. This is the Waste/Leftover material " +
                "mentioned in the summary screen. For your convenience, I've added a label showing you the value of this leftover product." +
                " I calculate the total profit by subtracting all inputs so all of this leftover material value is EXTRA profit. If you then use " +
                "these materials on another run, the value has already been acounted for. If the waste/leftover material is extremely high, " +
                "that means there is a BP or reaction that has a high level of leftover material. you can adjust the runs per copy or number " +
                "of copies to try to get this leftover materials cost down if you like.");
            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("2.) Total Cost Per Item - This is your total cost per item to make the item yourself with the options you've chosen. " +
                "This includes taxes, job costs, cost of inputs, and any additional cost you've put into the \"Additional Cost\" field (see below)." +
                "You can consider this value your \"Break-Even\" value. If you sell each item at this price, you will have 0 profit. " +
                "It's important to know that the taxes that are calculated are based on the order type you've selected. If you're selling the" +
                " item to a buy order, you only have the sales tax. If you sell the item via a sell order, you also have a brokers fee. " +
                "The Eve University Wiki has a great article on this topic and how to reduce them. The skills you set in Step 2 affect the taxes " +
                "so please make sure those are set correctly.");
            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("3.) Additional Costs - This is a catch all field of any additional costs related to this BP. Common uses for this" +
                " field is Invention Cost (See the Blueprints Control for Invention Cost), the cost of the BP from an LP store such as the faction " +
                "warfare LP stores, any hauling costs associated with this production run if you are paying someone to haul either the inputs or outputs " +
                "or any fuel costs if you're moving it yourself and moving items via Jump Freighters. The additional costs are included in the " +
                "calculations for profit automatically.");

            helpBuilder.AppendLine("");
            helpBuilder.AppendLine("Finally, there is a cost breakdown screen to explain line by line how we got the total profit for the build plan." +
                " It includes input costs, output price, taxes on each, job costs, and any additional costs set by the user. You can use this to " +
                "double check numbers vs the in-game values for accuracy.");

            HelpTextbox.Text = helpBuilder.ToString();
        }
    }
}

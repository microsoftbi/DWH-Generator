DWH generator

# 简介

这个工具是用元数据来生成数据仓库代码的工具。

代码的工作方式参考了跟Data Vault相关的理论。

关于数据建模的介绍可以参考我先前的文章。

# 方法论

首先数据建模的理论参考的是Data Vault的方式，而不是传统的维度模型。

利用分层的理念，也就是STAGE，CORE和MART三层的设计。

数据加载是遵循的ELT的方式，首先数据先一对一加载到STAGE，然后在这层会对数据的历史变更进行记录，采用的不是SCD2的方法，而是INSERT
ONLY的方法，避免了物理更新对性能的影响。

# 为什么Data Vault

官方的说明很多，我自己也总结过一些，这里只简要论述：

很多人都知道数据仓库建模有维度模型，大家有没有想过为什么要用这种建模方式？确实这种方式如果你想建立一个cube会非常方便，但如果你压根就没想建cube，为什么还要遵循维度建模的方式呢？在核心数据仓库层是否有其它方法论可以参考？

你可以考虑Data
Vault的方式，它是把键，关系和基本信息都放在单独的表里去组织和维护，是我推荐的在核心数据仓库建模的方法论。

另外一个优势就是，你可以通过基于元数据的方式来构建核心数据仓库，相比于维度模型会更容易实现些。

# 遵从的架构

这个工具首先遵从ELT的架构：

-   数据首先抽取并且加载到数据仓库中。

-   然后再对数据进行处理。

具体的说是：

1.  数据先1对1的加载到Stage表里。

2.  对Stage表进行PSA处理，方便后续加载。

3.  从PSA加载到核心数据仓库中，也就是Data Vault。

4.  从Data Vault加载到Mart层中，这里可以有宽表，也可以有维度模型。

![image](https://raw.githubusercontent.com/microsoftbi/DWH-Generator/master/DEMO/README/media/369504955e285602c620c97fc24719f7.png)

# 工具范围

首先这个工具并没有覆盖整个数据仓库。

这个工具的设计初衷是为了让开发人员能够减少对于重复代码的开发，尤其是PSA以及Data
Vault这部分，完全可以通过对元数据的配置去自动生成，从而让开发人员会有更多的精力去关注数据的接入方式以及报表计算的逻辑。

这个工具从STAGE的表开始，开始生成PSA表，然后根据这些表，生成Data
Vault表。目前只支持Satellite,
Hub和Link表。也就是说，这个工具完成的是第二步和第三步的工作。

# 如何使用这个工具

这里简单做一个演示，假定：

-   有一个数据源GAMESTORE，里面有三张表。

-   数据仓库有两个数据库，一个是STAGE，一个是CORE。（MART不在工具范围内）

我们将从创建这个数据源数据库，以及两个数据仓库数据库开始，然后把数据从数据源仓库加载到STAGE里。最后用工具去配置，生成PSA以及DV的表，视图以及存储过程。

接下来打开项目下的三个脚本：

1.  运行第一个脚本，它会帮你生成示例的数据源数据库。

2.  运行第二个脚本，它会帮你生成数据仓库数据库，这里只包含了STAGE和CORE数据库，以及STAGE下对应数据源的Stage表。

3.  运行第三个脚本，它会把数据从数据源加载到数据仓库STAGE里。

然后运行这个工具。

![image](https://raw.githubusercontent.com/microsoftbi/DWH-Generator/edit/master/DEMO/README/media/357b7a4fce86e824835d7671211f7833.png)

这个工具界面的主要元素是生成的代码。

顶部菜单项可以对元数据进行配置。

首先打开Configuration:

![image](https://raw.githubusercontent.com/microsoftbi/DWH-Generator/edit/master/DEMO/README/media/5f2b811760a30438e6da7ab279ae0b7c.png)

这里可以查看数据库的连接，不过修改只能在config文件里进行。

以及查看META数据库的部署脚本。这里需要把里面的META脚本复制出来运行。为确保后续步骤的运行请确保这个数据库部署成功。

Layers配置数据仓库数据库名，可以根据自己的项目去更改。

![image](https://raw.githubusercontent.com/microsoftbi/DWH-Generator/edit/master/DEMO/README/media/2e4d3eeaffff9c1541df5db44432bb44.png)

以及Data Vault数据表的配置。这里指定DataVault表的名称，后续
在配置字段映射的时候需要前面对应的ID进行配置。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/08d5c819d0c0b8aa4052c3e5a9975db0.png)

和Record
Source的配置。这个字段里记录的是数据源的简要信息，以及在Stage数据库里对应的Schema的信息。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/39c9471da6b878e5e33ceb2341795fc5.png)

这里面遵循的方式是，STAGE里根据不同数据源来的表都单独放在独立的schema里，同时也作为record
source信息进行维护。

基础部分设置完毕接下来设置元数据映射部分。

首先需要导入元数据，通过META Import。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/40c8af1df737f38e69785bd444cf7743.png)

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/b1198eddc57806bc711a4198ae812d04.png)

这里指定STAGE表的名称，比如gs.CUSTOMER。

然后点击Check the stage table meta，主要检查是否已经包含了必要的technical字段。

如果通过检查，就可以点击Load to META把这个表的元数据导入了。

![image](https://github.com/microsoftbi/DWH-Generator/edit/master/DEMO/README/media/be2a3dfb1a71312f069197b904a15b8b.png)

接下来点击Object to generate，需要指定配置哪个表的生成。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/ba8d113189c27d36de3c83c7ad8f2f72.png)

这里勾选第一行IS_GEN列。

点击菜单的Configuration，打开字段配置。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/56180f83e58145f1d5cf342b7c37f301.png)

这里需要指定数据的用法。

首先指定列CustomerID的PK和BK属性为true，并且设置DI为false。

设置表CUSTOMER的DV_SAT_ID为1，对应刚才配置的S_CUSTOMER表。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/37e26c1210aa5b1bcf97233c2fa3e017.png)

最后回到主界面点击菜单项的re-generate就可以生成对应的代码了。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/684ede929c28a399ecac1fd9475a361a.png)

可以看到生成的所有PSA层的对象。

同时也可以点击菜单Deploy下的PSA data flow来把PSA的脚本直接部署到数据仓库中。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/cc99145447fe0c9f13c1f6d9295a2ede.png)

部署成功后可以点击Scripts下的Execute PSA data flow来获取运行PSA的代码。

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/6ecc4df5e8a540b5473036188e39828a.png)

![image](https://github.com/microsoftbi/DWH-Generator/master/DEMO/README/media/9b4746cbe19d2e20b2d3a28c5cf2b432.png)

可以将这个脚本复制出来运行查看数据在PSA层运行的结果。

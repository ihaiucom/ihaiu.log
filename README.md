# ihaiu.log
包装一成Unity的日志。可以更方便查询和设置开关，以及输出成html然后上传服务器。这样很方便用浏览器查看，不用看手机那么小的屏幕。


### 开发过程
**第一步：** 定义Class,为了其他代码方便调用，所以就不用namespace。本来想参照Android的Log,但因为是想包装Unity的Debug，它里面有一个Log的Method。所以为了不冲突就叫MDebug。

**第二步：** 先实现Unity Debug一样的接口

**第三步：** 我们再加一套Metho接口，在每个方法第一个参数前面加一个bool isopen。目的是为了调试的时候开启，调试完关闭。比如你刚写一个网络模块的代码，你可以在这个模块定义一个静态变量传到这个参数，只在调试的时间启用，确保没什么问题了就关闭，然后应用到项目中你不敢确保完全没bug，但又不想下次调试时又去写log。（当然经过足够的应用测试，确保这个模块没问题了，你就可以把这个模块的日志删掉）

**第四步：** 我们定义tag参数，类似于Andriod日志里的tag。方便查看过滤。

**第五步：** 我们定义一个模块过滤器flag，方便用生成配置并且可以统一配置是否开启，优点是可以再游戏发布后动态修改。不像isopen写死在代码里，虽然这个也可以自己定义好动态修改，但是不能有tag。

**第六步：** 我们写一个日志配置

		**功能一：** 	用来实现类似Debug.logger.filterLogType的功能，他这个用的是级别。我想用的是Mask的形式，这样可以成复选框，设置的时间比较清晰直接。

		**功能二：** 用于配置flag

**第七步：** 定义日志输出格式： datetime;flagid;tag;msg

**第八步：** 写日志缓存
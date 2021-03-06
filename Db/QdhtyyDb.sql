SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_TaskTtype]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_TaskTtype](
	[TID] [char](1) NULL,
	[Tname] [varchar](10) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_TaskTtype', @level2type=N'COLUMN', @level2name=N'TID'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_User](
	[UID] [varchar](10) NULL,
	[Uname] [varchar](20) NULL,
	[UcNO] [varchar](10) NULL,
	[Upda] [varchar](10) NULL,
	[Upwd] [varchar](50) NULL,
	[Uoper] [varchar](20) NULL,
	[UopTime] [smalldatetime] NULL,
	[Ustate] [char](1) NULL,
	[Utype] [char](1) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_User', @level2type=N'COLUMN', @level2name=N'UID'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetTKtype]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[SDP_GetTKtype]
	@PID	varchar(20),---PDA的ID号
	@PNO	varchar(10)--终端编号
as
begin
	---@PID用于今后判断PDA的合法性
	select TID,Tname from TPDA_TaskType order by TID
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_EmpList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_EmpList](
	[Emp] [varchar](10) NULL,
	[EID] [varchar](40) NULL,
	[EIP] [varchar](100) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_EmpList', @level2type=N'COLUMN', @level2name=N'EID'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_TaskINQ]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_TaskINQ](
	[TK_IID] [int] IDENTITY(1,1) NOT NULL,
	[TK_date] [char](10) NULL,
	[TK_BNO] [varchar](10) NULL,
	[TK_Bname] [varchar](30) NULL,
	[TK_Pdate] [varchar](10) NULL,
	[TK_Note] [varchar](100) NULL,
	[TK_PNO] [varchar](20) NULL,
	[TK_oper] [varchar](10) NULL,
	[TK_opTime] [smalldatetime] NULL,
	[TK_State] [char](1) NULL,
	[TK_Rno] [varchar](10) NULL,
	[TK_Coper] [varchar](10) NULL,
	[TK_CopTime] [smalldatetime] NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_TaskINQ', @level2type=N'COLUMN', @level2name=N'TK_IID'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_BankInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_BankInfo](
	[Bno] [varchar](10) NULL,
	[Bname] [varchar](50) NULL,
	[BPID] [varchar](50) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_BankInfo', @level2type=N'COLUMN', @level2name=N'Bno'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_TaskEbank]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_TaskEbank](
	[TB_cid] [char](2) NOT NULL,
	[TB_date] [char](10) NOT NULL,
	[TB_Rno] [varchar](10) NOT NULL,
	[TB_BNO] [varchar](10) NOT NULL,
	[TB_Bname] [varchar](30) NULL,
	[TB_Ptime] [varchar](5) NULL,
	[TB_boxNum] [int] NULL,
	[TB_Notes] [varchar](20) NULL,
	[TB_oper] [varchar](10) NULL,
	[TB_opTime] [smalldatetime] NULL,
	[TB_State] [char](1) NULL,
	[TB_Type] [char](1) NULL,
	[TB_Stime] [varchar](10) NULL,
	[TB_Etime] [varchar](10) NULL,
	[TB_Tlen] [numeric](10, 2) NULL,
	[TB_KilM] [int] NULL,
	[TB_Fee] [int] NULL,
	[TB_Emp] [varchar](20) NULL,
	[TB_CNO] [varchar](20) NULL,
	[TB_Eva] [char](1) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_TaskEbank', @level2type=N'COLUMN', @level2name=N'TB_cid'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_PDASN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_PDASN](
	[PSN] [varchar](50) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_PDASN', @level2type=N'COLUMN', @level2name=N'PSN'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_BankFEE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_BankFEE](
	[TB_cid] [char](2) NOT NULL,
	[TB_date] [char](10) NOT NULL,
	[TB_BNO] [varchar](10) NOT NULL,
	[TB_Bname] [varchar](30) NULL,
	[TB_FName] [varchar](30) NULL,
	[TB_notes] [varchar](255) NULL,
	[TB_oper] [varchar](10) NULL,
	[TB_opTime] [smalldatetime] NULL,
	[TB_Fee] [int] NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_BankFEE', @level2type=N'COLUMN', @level2name=N'TB_cid'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_BOX]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_BOX](
	[BoxCID] [char](2) NOT NULL,
	[BoxNo] [varchar](10) NOT NULL,
	[BoxBno] [varchar](10) NOT NULL,
	[BoxType] [varchar](1) NULL,
	[BoxPdate] [varchar](10) NULL,
	[BoxScid] [char](2) NULL,
	[BoxSbno] [varchar](10) NULL,
	[BoxCstate] [char](1) NULL,
	[BoxDcid] [char](2) NULL,
	[BoxDBno] [varchar](10) NULL,
	[BoxOper] [varchar](20) NULL,
	[BoxOpTime] [smalldatetime] NULL,
	[BoxState] [char](1) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_BOX', @level2type=N'COLUMN', @level2name=N'BoxCID'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_PDAlist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_PDAlist](
	[PNO] [varchar](10) NULL,
	[PID] [varchar](30) NULL,
	[PCNO] [varchar](10) NULL,
	[PCID] [char](2) NULL,
	[Pstate] [char](1) NULL,
	[Poper] [varchar](20) NULL,
	[PopTime] [smalldatetime] NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_PDAlist', @level2type=N'COLUMN', @level2name=N'PID'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_TaskBank]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_TaskBank](
	[TB_cid] [char](2) NOT NULL,
	[TB_date] [char](10) NOT NULL,
	[TB_Rno] [varchar](10) NOT NULL,
	[TB_BNO] [varchar](10) NOT NULL,
	[TB_Bname] [varchar](30) NULL,
	[TB_Ptime] [varchar](5) NULL,
	[TB_boxNum] [int] NULL,
	[TB_notes] [varchar](255) NULL,
	[TB_oper] [varchar](10) NULL,
	[TB_opTime] [smalldatetime] NULL,
	[TB_State] [char](1) NULL,
	[TB_Type] [char](1) NULL,
	[TB_Stime] [varchar](10) NULL,
	[TB_Etime] [varchar](10) NULL,
	[TB_Tlen] [numeric](10, 2) NULL,
	[TB_KilM] [int] NULL,
	[TB_Fee] [int] NULL,
	[TB_Wxs] [int] NULL,
	[TB_Emp] [varchar](20) NULL,
	[TB_CNO] [varchar](20) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_TaskBank', @level2type=N'COLUMN', @level2name=N'TB_cid'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDA_TaskBox]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TPDA_TaskBox](
	[TB_CID] [char](2) NOT NULL,
	[TB_Date] [char](10) NOT NULL,
	[TB_RNO] [varchar](10) NOT NULL,
	[TB_BNO] [varchar](10) NULL,
	[TB_Bname] [varchar](20) NULL,
	[TB_BoxNO] [varchar](10) NOT NULL,
	[TB_BoxC0] [varchar](10) NULL,
	[TB_BoxC1] [varchar](10) NULL,
	[TB_InOut] [char](1) NULL,
	[TB_ToCID] [char](2) NULL,
	[TB_ToBno] [varchar](10) NULL,
	[TB_ToBname] [varchar](20) NULL,
	[TB_Otype] [char](1) NULL,
	[TB_Pdate] [varchar](10) NULL,
	[TB_State] [char](1) NULL
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TPDA_TaskBox', @level2type=N'COLUMN', @level2name=N'TB_CID'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[SDP_GetUser]
	@PID	varchar(20),---PDA的ID号
	@PNO	varchar(10)--终端编号
as
begin
	---@PID用于今后判断PDA的合法性
	select UID,Uname,UcNO,Upwd from TPDA_User where Upda=@PNO and Utype=''0'' order by UID
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_Login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[SDP_Login]
	@PID	varchar(20),---PDA的ID号
	@PNO	varchar(10),--终端编号
	@UID	varchar(10),
	@Pwd	varchar(50)
as
begin
	---@PID用于今后判断PDA的合法性
	if exists(select * from TPDA_User where UID=@UID and Upwd=@PWD) return 0
	else return -1
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetOper]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SDP_GetOper]
	@PID	varchar(20),---PDA的ID号
	@PNO	varchar(10)--终端编号
as
begin
	---@PID用于今后判断PDA的合法性
	select UID,Uname,UcNO,Upwd from TPDA_User where Upda=@PNO and Utype=''1'' order by UID
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetEmpJPG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SDP_GetEmpJPG]
	@Adate	varchar(10),---日期
	@PID	varchar(20),---PDA的ID号
	@PNO	varchar(10),--终端编号
	@EID	varchar(40), --卡的物理ID号
	@Emp	varchar(10) output,--客户经理号，点击任务是必须与任务的TB_Emp一致，否则提示进行身份验证
	@JpgIP	varchar(100) output---客户经理照片IP
as
declare	@CID	char(2),
		@Cno	varchar(10),
		@FIP	varchar(50)
begin
		set @Emp='''';
		set @JpgIP='''';
		
	---@PID用于今后判断PDA的合法性
		select @CID=Pcid,@Cno=PcNO from TPDA_PDAlist where PNO=@PNO	
		if @@rowcount=0 return -1 ---PDA非法
	
	---取客户经理编号EMP和客户经理照片IP
		select @Emp=Emp,@JpgIP=EIP from TPDA_EmpList where EID=@EID
		if @@rowcount<>1 return -2
	---客户经理IP，可以在表TPDA_EmpList中修改
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_UppInQTK]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[SDP_UppInQTK]
	@Adate	varchar(10),---当前日期
	@PID	varchar(20),---PDA的物理ID号
	@PNO	varchar(10),----PDA的编号
	@Pdate  varchar(10),----申请任务执行日期
	@Tnote	varchar(100)----任务申请说明
as
declare	@CID	char(2),
		@Cno	varchar(10),
		@Cname	varchar(30)
begin

set @Cname=''工行0101''

begin tran
	---@PID用于今后判断PDA的合法性
	select @CID=Pcid,@Cno=PcNO from TPDA_PDAlist where PNO=@PNO
	INSERT INTO TPDA_TaskINQ(TK_date,TK_BNO,TK_Bname,TK_Pdate,TK_Note,TK_PNO,TK_oper,TK_opTime,TK_State)
		values(@Adate,@CNO,@Cname,@Pdate,@Tnote,@PNO,@PNO,getdate(),''0'')
	if @@error<>0 or @@rowcount<>1
	begin
		rollback tran
		return -1
	end
commit tran
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetInQTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SDP_GetInQTask]
	@Adate	varchar(10),---申请日期，可以使机器的当前日期
	@PID	varchar(20),---PDA的物理ID号
	@PNO	varchar(10)----PDA的编号
as
declare	@CID	char(2),
		@Cno	varchar(10)
begin
	---@PID用于今后判断PDA的合法性
	select @CID=Pcid,@Cno=PcNO from TPDA_PDAlist where PNO=@PNO

	set rowcount 30

	SELECT TK_IID---唯一标识
      ,TK_date---申请日期
      ,TK_BNO----网点号
      ,TK_Bname---网点名称
      ,TK_Pdate---申请任务执行日期
      ,TK_Pdate+''--''+rtrim(TK_Note) TK_Note---任务申请说明
      ,TK_PNO----任务申请时使用的PDA号
      ,TK_oper----申请任务操作员
      ,TK_opTime----申请时间
      ,TK_State----申请状态：0.未响应，1.已响应、安排
      ,TK_Rno----安排的线路号：为空时表示未安排
      ,TK_Coper----响应人员
      ,TK_CopTime---响应时间
	FROM TPDA_TaskINQ where TK_Date<=@Adate and TK_PNO=@PNO order by TK_IID desc
	
	SET ROWCOUNT 0
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SNP_REQTSK]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SNP_REQTSK]
	@Adate	varchar(10),---申请的日期
	@PNO	varchar(10),---PDA号
	@BNO	varchar(10),---网点号
	@Oper	varchar(10),---操作员
	@Ptime	varchar(10),---申请任务执行日期
	@Note	varchar(50)---申请说明
as
declare	@CID	char(2),
		@Bname	varchar(30)
begin

set @Bname=''工行0101''

begin tran
	---@PID用于今后判断PDA的合法性
	select @CID=Pcid,@BNO=PcNO from TPDA_PDAlist where PNO=@PNO
	INSERT INTO TPDA_TaskINQ(TK_date,TK_BNO,TK_Bname,TK_Pdate,TK_Note,TK_PNO,TK_oper,TK_opTime,TK_State)
		values(@Adate,@BNO,@Bname,@Ptime,@Note,@PNO,@oper,getdate(),''0'')
	if @@error<>0 or @@rowcount<>1
	begin
		rollback tran
		return -1
	end
commit tran
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SNP_SaveETask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SNP_SaveETask]
	@PNO	varchar(10),---PDA编号
	@Adate	varchar(10),---任务日期
	@RNO	varchar(10),---任务号
	@BNO	varchar(10),---网点号
	@Stime	varchar(5),---起始时间：HH:MM
	@Etime	varchar(5),---结束时间:HH:MM
	@Kilm	int,		---行驶里程
	@Fee	int,		---费用
	@Eva	char(1),	---任务评价0,1,2
	@Oper	varchar(10)---UID号，持有PDA的用户编号
as
declare	@CID	char(2)
begin
select @CID=Pcid from TPDA_PDAlist where PNO=@PNO
begin tran
	UPDATE TPDA_TaskEBank
		SET TB_oper=@Oper,TB_opTime=getdate(),TB_State= ''1'',TB_Stime=@Stime,TB_Etime=@Etime,
			TB_KilM=TB_KilM,TB_Fee=TB_Fee,TB_Eva=@Eva
	WHERE 
        TB_Date=@Adate and 
        TB_RNO=@RNO and TB_Bno=@Bno and TB_State=''0''
	if @@error<>0 or @@rowcount<>1
	begin
		rollback tran
		return -1
	end
commit tran
return 0
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SNP_GetEmpTlist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[SNP_GetEmpTlist]
	@PNO	varchar(10),---PDA编号
	@MON	varchar(10),---年月，如2017-05
	@UID	varchar(10)---员工编号，即UID号
as
declare	@CID	char(2)
begin
select @CID=Pcid from TPDA_PDAlist where PNO=@PNO
select TB_date,		--日期
		TB_Type,	--任务类型
		TB_Bname,	--网点名称
		TB_TLen,	---工时
		TB_Fee		---费用合计
		from TPDA_TaskEBank where TB_CID=@CID and Left(TB_Date,7)=@MON and TB_Emp=@UID order by TB_Date
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SDP_GetTask]
	@Adate	varchar(10),---日期
	@PID	varchar(20),---PDA的ID号
	@PNO	varchar(10)--终端编号
as
declare	@CID	char(2),
		@Cno	varchar(10)
begin
	---@PID用于今后判断PDA的合法性
	if not exists(select * from TPDA_PDaSN where rtrim(PSN)=rtrim(@Pid))
		insert into TPDA_PdaSN values(@PID)
		
	select @CID=Pcid,@Cno=PcNO from TPDA_PDAlist where PNO=@PNO
	select * from TPDA_TaskBank where TB_CID=@CID
    --and TB_Date=@Adate 
    and TB_Bno=@Cno order by TB_Type
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetFeeQ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SDP_GetFeeQ]
	@AMON	varchar(7),	---月份
	@PNO	varchar(10),---终端编号
	@Btype	char(1)	---任务类型
as
declare	@CID	char(2),
		@Cno	varchar(10),
        @PCNO	varchar(10)
begin
	select @CID=Pcid,@PCNO=PCNO from TPDA_PDAlist where PNO=@PNO
	select TB_Date,TB_Fname,TB_Fee,TB_Notes
		from TPDA_BankFEE where TB_CID=@CID and Left(TB_Date,7)=@AMON and TB_Bno=@PCNO and Left(TB_Fname,1)=@Btype order by TB_Date
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SNP_ModiBox]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[SNP_ModiBox]
	@PNO	varchar(10),---PDA号
	@Bno	varchar(10),---网点号
	@Oper	varchar(10),---操作员
	@BoxNO	varchar(10),---尾箱号
	@Btype	char(1),	---同@Otype
	@Pdate	varchar(10),---预计出库日期
	@ToCID	char(2),	---目标中心
	@ToBno	varchar(10)--目标网点号
as
declare	@CID	char(2)
begin
	select @CID=PCID from TPDA_PDAlist where PNO=@PNO

begin tran
	update TPDA_BOX set	BoxType=@Btype
      ,BoxPdate=@Pdate
      ,BoxDcid=@ToCID
      ,BoxDBno=@ToBno,BoxOper=@oper,BoxOpTime=getdate()
	where BoxCID=@CID and BoxBNO=@BNO and BoxNO=@BoxNO
	if @@error<>0 or @@rowcount<>1
	begin
		rollback tran
		return -1
	end
commit tran
end 

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SNP_GetBOXList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SNP_GetBOXList]
	@PNO	varchar(10),---PDA号
	@Bno	varchar(10)---网点号
as
declare	@CID	char(2),@PCNO	varchar(10)
begin
	select @CID=PCID,@PCNO=PCNO from TPDA_PDAlist where PNO=@PNO

	SELECT BoxCID
      ,BoxNo
      ,BoxBno
      ,BoxType
      ,BoxPdate
      ,BoxState
      ,BoxDcid
      ,BoxDBno
	FROM TPDA_BOX where BoxCID=@CID and BoxBNO=@PCNO order by BoxNO
end 

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetFeeA_XXX]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SDP_GetFeeA_XXX]
	@AMON	varchar(7),	---月份
	@PNO	varchar(10),---终端编号
	@Btype	char(1)	---任务类型
as
declare	@CID	char(2),
		@Cno	varchar(10)
begin
	select @CID=Pcid,@Cno=PCNO from TPDA_PDAlist where PNO=@PNO
	select TB_Date 日期,TB_Type 类型,TB_STime 起始时间,TB_ETime 结束时间,TB_Fee 费用,TB_Notes 说明
		from TPDA_TaskBank where TB_CID=@CID and Left(TB_Date,7)=@AMON and TB_Bno=@CNO and TB_Type=@Btype
    order by TB_Date
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SDP_GetEtask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SDP_GetEtask]
	@Adate	varchar(10),---日期
	@PID	varchar(20),---PDA的ID号
	@PNO	varchar(10),--终端编号
	@Uid	varchar(10)---PDA的用户号
as
declare	@CID	char(2),
		@Cno	varchar(10)
begin
	---@PID用于今后判断PDA的合法性
	select @CID=Pcid,@Cno=PcNO from TPDA_PDAlist where PNO=@PNO
	select * from TPDA_TaskEBank where TB_CID=@CID order by TB_Ptime
    --and TB_Date=@Adate 
---    and TB_Bno=@Cno 
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SNP_UppBox]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SNP_UppBox]
	@Adate	varchar(10),--当前日期
	@PNO	varchar(10),--PDA编号
	@Oper	varchar(10),--银行操作员
	@RNO	varchar(10),--线路号
	@Bno	varchar(10),--网点号
	@BoxNO	varchar(10),--尾箱号
	@ToCID	char(2),	--目标中心
	@ToBno	varchar(10),--目标网点号
	@Otype	char(1),
    @ODate varchar(10),--出库日期
	@Pdate	varchar(10)
as
declare	@CID	char(2)
begin
	select @CID=PCID from TPDA_PDAlist where PNO=@PNO
	
	if exists(select * from TPDA_TaskBox where TB_CID=@CID and TB_Date=@Adate and TB_RNO=@RNO and TB_BNO=@BNO
		and TB_BoxNO=@BoxNO) return -1	
begin tran
	INSERT INTO TPDA_TaskBox
           (TB_CID
           ,TB_Date
           ,TB_RNO
           ,TB_BNO
           ,TB_BoxNO
           ,TB_BoxC0
           ,TB_InOut
           ,TB_ToCID
           ,TB_ToBno
           ,TB_Pdate
           ,TB_State,TB_Otype)
    values(@CID
           ,@ADate
           ,@RNO
           ,@BNO
           ,@BoxNO
           ,@Oper
           ,''1''
           ,@ToCID
           ,@ToBno
           ,@Pdate
           ,''0'',@Otype)
     if @@error<>0 or @@rowcount<>1
     begin
		rollback tran
		return -2
     end
commit tran
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SNP_SaveTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[SNP_SaveTask]
	@CID	char(2),
	@Adate	varchar(10),
	@RNO	varchar(10),
	@BNO	varchar(10),
	@Stime	varchar(5),
	@Etime	varchar(5),
	@Kilm	int,
	@Fee	int,
	@Oper	varchar(10)
as
begin
begin tran
	UPDATE TPDA_TaskBank
		SET TB_oper=@Oper,TB_opTime=getdate(),TB_State= ''1'',TB_Stime=@Stime,TB_Etime=@Etime,
			TB_KilM=TB_KilM,TB_Fee=TB_Fee
	WHERE TB_CID=@CID and TB_Date=@Adate and TB_RNO=@RNO and TB_Bno=@Bno
	if @@error<>0 or @@rowcount<>1
	begin
		rollback tran
		return -1
	end
commit tran
return 0
end
' 
END

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoicDreams.BlazorUI.Auth;

public class AuthenticateTests : TestFramework
{
	[Theory]
	[InlineData(false, TestRoles.Guest, 1)]
	[InlineData(true, TestRoles.One, 1)]
	[InlineData(false, TestRoles.One, 0)]
	[InlineData(true, TestRoles.Guest, 0)]
	public void Verify_IsRole(bool expectedResult, TestRoles checkRole, int currentRoles)
	{
		IActions<MockAuthenticate> actions = ArrangeUnitTest<MockAuthenticate>(options =>
		{
		});

		actions.Act(a => a.Service.User = new User() { Role = currentRoles });

		actions.Assert(a =>
		{
			Assert.Equal(expectedResult, a.Service.IsRole((int)checkRole));
		});
	}

	public enum TestRoles
	{
		Guest = 0,
		One = 1,
		Two = 2,
		Four = 4
	}
}

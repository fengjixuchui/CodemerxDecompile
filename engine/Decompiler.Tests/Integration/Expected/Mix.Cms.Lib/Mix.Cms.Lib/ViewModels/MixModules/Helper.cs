using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Mix.Cms.Lib.Models.Cms;
using Mix.Cms.Lib.ViewModels.MixCultures;
using Mix.Common.Helper;
using Mix.Domain.Core.Models;
using Mix.Domain.Core.ViewModels;
using Mix.Domain.Data.Repository;
using Mix.Domain.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Mix.Cms.Lib.ViewModels.MixModules
{
	public class Helper
	{
		public Helper()
		{
		}

		public static RepositoryResponse<Mix.Cms.Lib.ViewModels.MixModules.UpdateViewModel> GetBy(Expression<Func<MixModule, bool>> predicate, string postId = null, string productId = null, int pageId = 0, MixCmsContext _context = null, IDbContextTransaction _transaction = null)
		{
			RepositoryResponse<Mix.Cms.Lib.ViewModels.MixModules.UpdateViewModel> singleModel = ViewModelBase<MixCmsContext, MixModule, Mix.Cms.Lib.ViewModels.MixModules.UpdateViewModel>.Repository.GetSingleModel(predicate, _context, _transaction);
			if (singleModel.get_IsSucceed())
			{
				singleModel.get_Data().PostId = postId;
				singleModel.get_Data().PageId = pageId;
			}
			return singleModel;
		}

		public static async Task<RepositoryResponse<bool>> Import(List<MixModule> arrModule, string destCulture, MixCmsContext _context = null, IDbContextTransaction _transaction = null)
		{
			Helper.u003cImportu003ed__0 variable = new Helper.u003cImportu003ed__0();
			variable.arrModule = arrModule;
			variable.destCulture = destCulture;
			variable._context = _context;
			variable._transaction = _transaction;
			variable.u003cu003et__builder = AsyncTaskMethodBuilder<RepositoryResponse<bool>>.Create();
			variable.u003cu003e1__state = -1;
			variable.u003cu003et__builder.Start<Helper.u003cImportu003ed__0>(ref variable);
			return variable.u003cu003et__builder.Task;
		}

		public static List<SupportedCulture> LoadCultures(int id, string initCulture = null, MixCmsContext _context = null, IDbContextTransaction _transaction = null)
		{
			Helper.u003cu003ec__DisplayClass1_0 variable = null;
			RepositoryResponse<List<SystemCultureViewModel>> modelList = ViewModelBase<MixCmsContext, MixCulture, SystemCultureViewModel>.Repository.GetModelList(_context, _transaction);
			List<SupportedCulture> supportedCultures = new List<SupportedCulture>();
			if (modelList.get_IsSucceed())
			{
				foreach (SystemCultureViewModel datum in modelList.get_Data())
				{
					List<SupportedCulture> supportedCultures1 = supportedCultures;
					SupportedCulture supportedCulture = new SupportedCulture();
					supportedCulture.set_Icon(datum.Icon);
					supportedCulture.set_Specificulture(datum.Specificulture);
					supportedCulture.set_Alias(datum.Alias);
					supportedCulture.set_FullName(datum.FullName);
					supportedCulture.set_Description(datum.FullName);
					supportedCulture.set_Id(datum.Id);
					supportedCulture.set_Lcid(datum.Lcid);
					supportedCulture.set_IsSupported((datum.Specificulture == initCulture ? true : _context.MixModule.Any<MixModule>((MixModule p) => p.Id == variable.id && p.Specificulture == datum.Specificulture)));
					supportedCultures1.Add(supportedCulture);
				}
			}
			return supportedCultures;
		}
	}
}
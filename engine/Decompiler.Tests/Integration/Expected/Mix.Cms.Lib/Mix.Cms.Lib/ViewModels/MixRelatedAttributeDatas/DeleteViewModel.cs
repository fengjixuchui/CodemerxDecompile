using Microsoft.EntityFrameworkCore.Storage;
using Mix.Cms.Lib;
using Mix.Cms.Lib.Models.Cms;
using Mix.Domain.Data.ViewModels;
using System;
using System.Runtime.CompilerServices;

namespace Mix.Cms.Lib.ViewModels.MixRelatedAttributeDatas
{
	public class DeleteViewModel : ViewModelBase<MixCmsContext, MixRelatedAttributeData, DeleteViewModel>
	{
		public int AttributeSetId
		{
			get;
			set;
		}

		public DateTime CreatedDateTime
		{
			get;
			set;
		}

		public string DataId
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string Id
		{
			get;
			set;
		}

		public string ParentId
		{
			get;
			set;
		}

		public MixEnums.MixAttributeSetDataType ParentType
		{
			get;
			set;
		}

		public string Specificulture
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}

		public DeleteViewModel()
		{
		}

		public DeleteViewModel(MixRelatedAttributeData model, MixCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
		{
		}

		public override MixRelatedAttributeData ParseModel(MixCmsContext _context = null, IDbContextTransaction _transaction = null)
		{
			if (this.CreatedDateTime == new DateTime())
			{
				this.CreatedDateTime = DateTime.UtcNow;
			}
			return base.ParseModel(_context, _transaction);
		}
	}
}
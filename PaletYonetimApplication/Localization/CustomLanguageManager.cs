using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Localization
{
	public class CustomLanguageManager:LanguageManager
	{
        public CustomLanguageManager()
        {
			AddTranslation("tr", "GreaterThan", "'{PropertyName}' alanı {ComparisonValue}'den büyük olmalıdır.");
			AddTranslation("tr", "LessThan", "'{PropertyName}' alanı {ComparisonValue}'den küçük olmalıdır.");
			AddTranslation("tr", "NotEmpty", "'{PropertyName}' alanı boş bırakılamaz.");
			AddTranslation("tr", "MaximumLength", "'{PropertyName}' alanı {MaxLength} karakterden uzun olamaz.");
			AddTranslation("tr", "MinimumLength", "'{PropertyName}' alanı {MinLength} karakterden kısa olamaz.");
			AddTranslation("tr", "EmailValidator", "'{PropertyName}' alanı geçerli bir e-posta adresi olmalıdır.");
			AddTranslation("tr", "Length", "'{PropertyName}' alanı {MinLength} ile {MaxLength} karakter arasında olmalıdır.");
		}
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.GameContent.UI.Chat;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.States;

public sealed class UILanguageSelectMenu : UIState
{
	public sealed class UIGameCultureListItem : UIElement
	{
		// TODO: Pre-compute localization key amounts and communicate them here.
		private static readonly Color localization_keys_100 = Colors.RarityGreen;
		private static readonly Color localization_keys_000 = Colors.RarityRed;

		public GameCulture Culture { get; }

		private readonly UILanguageSelectMenu menu;

		public UIGameCultureListItem(GameCulture culture, UILanguageSelectMenu menu)
		{
			Culture = culture;
			this.menu = menu;
			OnLeftClick += SetLanguage;
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);

			CalculatedStyle dimensions = GetDimensions();
			float maxWidth = dimensions.Width + 1f;
			Vector2 position = new(dimensions.X, dimensions.Y);
			Color panelColor = new(63, 82, 151);
			Vector2 baseScale = new(0.8f);

			if (IsMouseHovering)
			{
				panelColor = panelColor.MultiplyRGBA(new Color(180, 180, 180));
			}

			string name = Culture.NativeName;

			if (Culture.NativeName != Culture.EnglishName)
			{
				name += " / " + Culture.EnglishName;
			}

			// TODO: Compute translation progress.
			string progress = "??/?? (100%)";

			Utils.DrawSettingsPanel(spriteBatch, position, maxWidth, panelColor);

			position.X += 8f;
			position.Y += 8f;

			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, name, position, IsMouseHovering ? Color.Silver : Color.White, 0f, Vector2.Zero, baseScale, maxWidth);

			Vector2 stringSize = ChatManager.GetStringSize(FontAssets.ItemStack.Value, progress, baseScale);
			position = new Vector2(dimensions.X + dimensions.Width - stringSize.X - 10f, dimensions.Y + 8f);
			GlyphTagHandler.GlyphsScale = 0.85f;
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, progress, position, IsMouseHovering ? Color.Silver : Color.White, 0f, Vector2.Zero, baseScale, maxWidth);
			GlyphTagHandler.GlyphsScale = 1f;
		}

		private void SetLanguage(UIMouseEvent e, UIElement el)
		{
			LanguageManager.INSTANCE.SetLanguage(Culture);
			Main.SaveSettings();
			menu.Recalculate();
			Main.changeTheTitle = true;

			if (menu.usedForFirstTimeSetup)
			{
				Main.menuMode = 0;
			}
		}
	}

	private readonly bool usedForFirstTimeSetup;

	public UILanguageSelectMenu(bool usedForFirstTimeSetup)
	{
		this.usedForFirstTimeSetup = usedForFirstTimeSetup;
	}

	public override void OnActivate()
	{
		base.OnActivate();

		UIElement outerContainer = new();
		outerContainer.Width.Set(0f, 0.8f);
		outerContainer.MaxWidth.Set(600f, 0f);
		outerContainer.Top.Set(220f, 0f);
		outerContainer.Height.Set(-200f, 1f);
		outerContainer.HAlign = 0.5f;

		UIPanel backPanel = new();
		backPanel.Width.Set(0f, 1f);
		backPanel.Height.Set(-110f, 1f);
		backPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;

		UIList languageList = new();
		languageList.Width.Set(-25f, 1f);
		languageList.Height.Set(-10f, 1f);
		languageList.VAlign = 1f;
		languageList.ListPadding = 4f;
		backPanel.Append(languageList);

		UIScrollbar scrollbar = new();
		scrollbar.SetView(100f, 1000f);
		scrollbar.Height.Set(0f, 1f);
		scrollbar.HAlign= 1f;
		scrollbar.VAlign = 1f;
		backPanel.Append(scrollbar);
		languageList.SetScrollbar(scrollbar);

		outerContainer.Append(backPanel);

		UITextPanel<LocalizedText> selectLanguageText = new(Lang.menu[102], 0.7f, large: true);
		selectLanguageText.HAlign = 0.5f;
		selectLanguageText.Top.Set(-45f, 0f);
		selectLanguageText.SetPadding(15f);
		selectLanguageText.BackgroundColor = new Color(73, 94, 171);
		outerContainer.Append(selectLanguageText);

		if (!usedForFirstTimeSetup)
		{
			UITextPanel<LocalizedText> backButton = new(Language.GetText("UI.Back"), 0.7f, large: true);
			backButton.Width.Set(-10f, 0.5f);
			backButton.Height.Set(50f, 0f);
			backButton.VAlign = 1f;
			backButton.HAlign = 0.5f;
			backButton.Top.Set(-45f, 0f);
			backButton.OnMouseOver += FadedMouseOver;
			backButton.OnMouseOut += FadedMouseOut;
			backButton.OnLeftClick += GoBack;
			outerContainer.Append(backButton);
		}

		Append(outerContainer);

		PopulateListWithLanguages(languageList, this);
	}

	private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
	{
		SoundEngine.PlaySound(12);
		((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		((UIPanel)evt.Target).BorderColor = Colors.FancyUIFatButtonMouseOver;
	}

	private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
	{
		((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		((UIPanel)evt.Target).BorderColor = Color.Black;
	}

	private void GoBack(UIMouseEvent evt, UIElement listeningElement)
	{
		Main.menuMode = 11;
	}

	private static void PopulateListWithLanguages(UIList list, UILanguageSelectMenu menu) {
		foreach (GameCulture culture in Languages.GameCultures.Values)
		{
			list.Add(ElementFromGameCulture(culture, menu));
		}
	}

	private static UIElement ElementFromGameCulture(GameCulture culture, UILanguageSelectMenu menu)
	{
		UIGameCultureListItem item = new(culture, menu);
		item.Width.Set(0f, 1f);
		item.Height.Set(30f, 0f);
		return item;
	}
}

using System;
using System.Collections.Generic;

namespace Terraria.Localization;

/// <summary>
///     Supported languages.
/// </summary>
public static class Languages
{
	/// <summary>
	///     English, en-US, United States.
	/// </summary>
	public static GameCulture English { get; } = new EnglishGameCulture();

	/// <summary>
	///     German, de-DE, Germany.
	/// </summary>
	public static GameCulture German { get; } = new GermanGameCulture();

	/// <summary>
	///     Italian, it-IT, Italy.
	/// </summary>
	public static GameCulture Italian { get; } = new ItalianGameCulture();

	/// <summary>
	///     Franch, fr-FR, France.
	/// </summary>
	public static GameCulture French { get; } = new FrenchGameCulture();

	/// <summary>
	///     Spanish, es-ES, Spain.
	/// </summary>
	public static GameCulture Spanish { get; } = new SpanishGameCulture();

	/// <summary>
	///     Russian, ru-RU, Russia.
	/// </summary>
	public static GameCulture Russian { get; } = new RussianGameCulture();

	/// <summary>
	///     Chinese, zh-Hans, China.
	/// </summary>
	public static GameCulture SimplifiedChinese { get; } = new SimplifiedChineseGameCulture();

	/// <summary>
	///     Portuguese, pt-BR, Brazil.
	/// </summary>
	public static GameCulture BrazilianPortuguese { get; } = new BrazilianPortugueseGameCulture();

	/// <summary>
	///     Polish, pl-PL, Poland.
	/// </summary>
	public static GameCulture Polish { get; } = new PolishGameCulture();

	/// <summary>
	///		A name-<see cref="GameCulture"/> map of all supported cultures.
	/// </summary>
	public static Dictionary<string, GameCulture> GameCultures { get; } = new();

	static Languages()
	{
		AddCulture(English);
		AddCulture(German);
		AddCulture(Italian);
		AddCulture(French);
		AddCulture(Spanish);
		AddCulture(Russian);
		AddCulture(SimplifiedChinese);
		AddCulture(BrazilianPortuguese);
		AddCulture(Polish);
	}

	/// <summary>
	///		Registers a culture to the known culture map.
	/// </summary>
	/// <param name="culture">The culture to register.</param>
	public static void AddCulture(GameCulture culture)
	{
		GameCultures.Add(culture.LanguageCode, culture);
	}

	private sealed class EnglishGameCulture : GameCulture
	{
		public EnglishGameCulture() : base("en-US", "English (United States)", "English (United States)") { }
	}

	private sealed class GermanGameCulture : GameCulture
	{
		public GermanGameCulture() : base("de-DE", "German", "Deutsch") { }
	}

	private sealed class ItalianGameCulture : GameCulture
	{
		public ItalianGameCulture() : base("it-IT", "Italian", "Italiano") { }
	}

	private sealed class FrenchGameCulture : GameCulture
	{
		public FrenchGameCulture() : base("fr-FR", "French", "Français") { }
	}

	private sealed class SpanishGameCulture : GameCulture
	{
		public SpanishGameCulture() : base("es-ES", "Spanish", "Español") { }
	}

	private sealed class RussianGameCulture : GameCulture
	{
		public RussianGameCulture() : base("ru-RU", "Russian", "Русский") { }
	}

	private sealed class SimplifiedChineseGameCulture : GameCulture
	{
		public SimplifiedChineseGameCulture() : base("zh-Hans", "Chinese (Simplified)", "简体中文") { }
	}

	private sealed class BrazilianPortugueseGameCulture : GameCulture
	{
		public BrazilianPortugueseGameCulture() : base("pt-BR", "Portuguese (Brazil)", "Português (Brasil)") { }
	}

	private sealed class PolishGameCulture : GameCulture
	{
		public PolishGameCulture() : base("pl-PL", "Polish", "Polski") { }
	}
}

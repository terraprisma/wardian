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
		GameCultures.Add(culture.Name, culture);
	}

	// UNSUPPORTED
	internal static GameCulture DangerousGetCultureFromLegacyId(int id)
	{
		return id switch
		{
			1 => English,
			2 => German,
			3 => Italian,
			4 => French,
			5 => Spanish,
			6 => Russian,
			7 => SimplifiedChinese,
			8 => BrazilianPortuguese,
			9 => Polish,
			_ => throw new IndexOutOfRangeException(nameof(id)),
		};
	}

	private sealed class EnglishGameCulture : GameCulture
	{
		public EnglishGameCulture() : base("en-US") { }
	}

	private sealed class GermanGameCulture : GameCulture
	{
		public GermanGameCulture() : base("de-DE") { }
	}

	private sealed class ItalianGameCulture : GameCulture
	{
		public ItalianGameCulture() : base("it-IT") { }
	}

	private sealed class FrenchGameCulture : GameCulture
	{
		public FrenchGameCulture() : base("fr-FR") { }
	}

	private sealed class SpanishGameCulture : GameCulture
	{
		public SpanishGameCulture() : base("es-ES") { }
	}

	private sealed class RussianGameCulture : GameCulture
	{
		public RussianGameCulture() : base("ru-RU") { }
	}

	private sealed class SimplifiedChineseGameCulture : GameCulture
	{
		public SimplifiedChineseGameCulture() : base("zh-Hans") { }
	}

	private sealed class BrazilianPortugueseGameCulture : GameCulture
	{
		public BrazilianPortugueseGameCulture() : base("pt-BR") { }
	}

	private sealed class PolishGameCulture : GameCulture
	{
		public PolishGameCulture() : base("pl-PL") { }
	}
}

using Shelly.Abstractions.TwoFactor.Providers.Qr;
using Shelly.Abstractions.TwoFactor.Providers.Rng;
using Shelly.Abstractions.TwoFactor.Providers.Time;

namespace Shelly.Abstractions.TwoFactor
{
     public static class DefaultProviders
     {
          /// <summary>
          /// Gets the default RNG provider
          /// </summary>
          /// <seealso cref="IRngProvider"/>
          public static IRngProvider DefaultRngProvider { get { return new DefaultRngProvider(); } }

          /// <summary>
          /// Gets the default QR Code provider
          /// </summary>
          /// <seealso cref="IQrCodeProvider"/>
          public static IQrCodeProvider DefaultQrCodeProvider { get { return new QrServerQrCodeProvider(); } }

          /// <summary>
          /// Gets the default Time provider
          /// </summary>
          /// <seealso cref="ITimeProvider"/>
          public static ITimeProvider DefaultTimeProvider { get { return new LocalMachineTimeProvider(); } }

     }
}

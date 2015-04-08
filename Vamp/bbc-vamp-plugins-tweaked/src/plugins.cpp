// This is a skeleton file for use in creating your own plugin
// libraries.  Replace MyPlugin and myPlugin throughout with the name
// of your first plugin class, and fill in the gaps as appropriate.

#include <vamp/vamp.h>
#include <vamp-sdk/PluginAdapter.h>

#include "Energy.h"
#include "Intensity.h"
#include "SpectralFlux.h"
#include "Rhythm.h"
#include "SpectralContrast.h"
#include "SpeechMusicSegmenter.h"
#include "Peaks.h"

// Declare one static adapter here for each plugin class in this library.
namespace vampBBC{
static Vamp::PluginAdapter<Energy> energy;
static Vamp::PluginAdapter<Intensity> intensity;
static Vamp::PluginAdapter<SpectralFlux> flux;
static Vamp::PluginAdapter<Rhythm> rhythm;
static Vamp::PluginAdapter<SpectralContrast> spectralcontrast;
static Vamp::PluginAdapter<SpeechMusicSegmenter> speechMusicSegmenter;
static Vamp::PluginAdapter<Peaks> peaks;

// This is the entry-point for the library, and the only function that
// needs to be publicly exported.

const VampPluginDescriptor *
vampGetPluginDescriptor(unsigned int version, unsigned int index) {
	if (version < 1)
		return 0;

	// Return a different plugin adaptor's descriptor for each index,
	// and return 0 for the first index after you run out of plugins.
	// (That's how the host finds out how many plugins are in this
	// library.)

	switch (index) {
	case 0:
		return energy.getDescriptor();
	case 1:
		return intensity.getDescriptor();
	case 2:
		return flux.getDescriptor();
	case 3:
		return rhythm.getDescriptor();
	case 4:
		return spectralcontrast.getDescriptor();
	case 5:
		return speechMusicSegmenter.getDescriptor();
  case 6:
    return peaks.getDescriptor();
	default:
		return 0;
	}
}

}
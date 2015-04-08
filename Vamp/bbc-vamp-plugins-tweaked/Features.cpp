public class Feature
    {
	/**
	 * True if an output feature has its own timestamp.  This is
	 * mandatory if the output has VariableSampleRate, optional if
	 * the output has FixedSampleRate, and unused if the output
	 * has OneSamplePerStep.
	 */
	bool hasTimestamp;

	/**
	 * Timestamp of the output feature.  This is mandatory if the
	 * output has VariableSampleRate or if the output has
	 * FixedSampleRate and hasTimestamp is true, and unused
	 * otherwise.
	 */
	RealTime timestamp;

        /**
         * True if an output feature has a specified duration.  This
         * is optional if the output has VariableSampleRate or
         * FixedSampleRate, and and unused if the output has
         * OneSamplePerStep.
         */
        bool hasDuration;

        /**
         * Duration of the output feature.  This is mandatory if the
         * output has VariableSampleRate or FixedSampleRate and
         * hasDuration is true, and unused otherwise.
         */
        RealTime duration;
	
	/**
	 * Results for a single sample of this feature.  If the output
	 * hasFixedBinCount, there must be the same number of values
	 * as the output's binCount count.
	 */
	std::vector<float> values;

	/**
	 * Label for the sample of this feature.
	 */
	std::string label;

        Feature() : // defaults for mandatory non-class-type members
            hasTimestamp(false), hasDuration(false) { }
    };

    typedef std::vector<Feature> FeatureList;

    typedef std::map<int, FeatureList> FeatureSet; // key is output no

    /**
     * Process a single block of input data.
     * 
     * If the plugin's inputDomain is TimeDomain, inputBuffers will
     * point to one array of floats per input channel, and each of
     * these arrays will contain blockSize consecutive audio samples
     * (the host will zero-pad as necessary).  The timestamp in this
     * case will be the real time in seconds of the start of the
     * supplied block of samples.
     *
     * If the plugin's inputDomain is FrequencyDomain, inputBuffers
     * will point to one array of floats per input channel, and each
     * of these arrays will contain blockSize/2+1 consecutive pairs of
     * real and imaginary component floats corresponding to bins
     * 0..(blockSize/2) of the FFT output.  That is, bin 0 (the first
     * pair of floats) contains the DC output, up to bin blockSize/2
     * which contains the Nyquist-frequency output.  There will
     * therefore be blockSize+2 floats per channel in total.  The
     * timestamp will be the real time in seconds of the centre of the
     * FFT input window (i.e. the very first block passed to process
     * might contain the FFT of half a block of zero samples and the
     * first half-block of the actual data, with a timestamp of zero).
     *
     * Return any features that have become available after this
     * process call.  (These do not necessarily have to fall within
     * the process block, except for OneSamplePerStep outputs.)
     */
    virtual FeatureSet process(const float *const *inputBuffers,
			       RealTime timestamp) = 0;

    /**
     * After all blocks have been processed, calculate and return any
     * remaining features derived from the complete input.
     */
    virtual FeatureSet getRemainingFeatures() = 0;

    /**
     * Used to distinguish between Vamp::Plugin and other potential
     * sibling subclasses of PluginBase.  Do not reimplement this
     * function in your subclass.
     */
    virtual std::string getType() { return "Feature Extraction Plugin"; }

protected:
    Plugin(float inputSampleRate) :
	m_inputSampleRate(inputSampleRate) { }

    float m_inputSampleRate;
};
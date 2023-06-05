namespace RtlTcp;

internal enum RtlCommands : byte
{
    SET_FREQ = 0x01,
    SET_SAMPLE_RATE = 0x02,
    SET_TUNER_GAIN_MODE = 0x03,
    SET_GAIN = 0x04,
    SET_FREQ_COR = 0x05,
    SET_AGC_MODE = 0x08,
    SET_TUNER_GAIN_INDEX = 0x0D
}

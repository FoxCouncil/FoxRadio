namespace Nrsc5;

public enum EventType
{
    LOST_DEVICE = 0,
    IQ = 1,
    SYNC = 2,
    LOST_SYNC = 3,
    MER = 4,
    BER = 5,
    HDC = 6,
    AUDIO = 7,
    ID3 = 8,
    SIG = 9,
    LOT = 10,
    SIS = 11
}

public enum ServiceType
{
    AUDIO = 0,
    DATA = 1
}

public enum ComponentType
{
    AUDIO = 0,
    DATA = 1
}

public enum MIMEType : uint
{
    PRIMARY_IMAGE = 0xBE4B7536,
    STATION_LOGO = 0xD9C72536,
    NAVTEQ = 0x2D42AC3E,
    HERE_TPEG = 0x82F03DFC,
    HERE_IMAGE = 0xB7F03DFC,
    HD_TMC = 0xEECB55B6,
    HDC = 0x4DC66C5A,
    TEXT = 0xBB492AAC,
    JPEG = 0x1E653E9C,
    PNG = 0x4F328CA0,
    TTN_TPEG_1 = 0xB39EBEB2,
    TTN_TPEG_2 = 0x4EB03469,
    TTN_TPEG_3 = 0x52103469,
    TTN_STM_TRAFFIC = 0xFF8422D7,
    TTN_STM_WEATHER = 0xEF042E96
}

public enum Access
{
    PUBLIC = 0,
    RESTRICTED = 1
}

public enum ServiceDataType
{
    NON_SPECIFIC = 0,
    NEWS = 1,
    SPORTS = 3,
    WEATHER = 29,
    EMERGENCY = 31,
    TRAFFIC = 65,
    IMAGE_MAPS = 66,
    TEXT = 80,
    ADVERTISING = 256,
    FINANCIAL = 257,
    STOCK_TICKER = 258,
    NAVIGATION = 259,
    ELECTRONIC_PROGRAM_GUIDE = 260,
    AUDIO = 261,
    PRIVATE_DATA_NETWORK = 262,
    SERVICE_MAINTENANCE = 263,
    HD_RADIO_SYSTEM_SERVICES = 264,
    AUDIO_RELATED_DATA = 265
}

public enum ProgramType
{
    UNDEFINED = 0,
    NEWS = 1,
    INFORMATION = 2,
    SPORTS = 3,
    TALK = 4,
    ROCK = 5,
    CLASSIC_ROCK = 6,
    ADULT_HITS = 7,
    SOFT_ROCK = 8,
    TOP_40 = 9,
    COUNTRY = 10,
    OLDIES = 11,
    SOFT = 12,
    NOSTALGIA = 13,
    JAZZ = 14,
    CLASSICAL = 15,
    RHYTHM_AND_BLUES = 16,
    SOFT_RHYTHM_AND_BLUES = 17,
    FOREIGN_LANGUAGE = 18,
    RELIGIOUS_MUSIC = 19,
    RELIGIOUS_TALK = 20,
    PERSONALITY = 21,
    PUBLIC = 22,
    COLLEGE = 23,
    SPANISH_TALK = 24,
    SPANISH_MUSIC = 25,
    HIP_HOP = 26,
    WEATHER = 29,
    EMERGENCY_TEST = 30,
    EMERGENCY = 31,
    TRAFFIC = 65,
    SPECIAL_READING_SERVICES = 76
}

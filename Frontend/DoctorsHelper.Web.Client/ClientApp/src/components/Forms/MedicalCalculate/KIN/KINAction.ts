import {
    ContrastInducedNephropathyResponse,
    ContrastInducedNephropathyClient
} from "../../../../apiClient/apiClient";
import {IResult} from "../../../../common/Interfaces";
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function KINResult(
    isHypotonia: boolean,
    isVABK: boolean,
    isNYHA: boolean,
    isOldAge: boolean,
    isAnemya: boolean,
    isDiabetes: boolean,
    isBigCreatinin: boolean,
    volumeContrast: number,
    speedKF: number
) {
    let res: IResult<ContrastInducedNephropathyResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new ContrastInducedNephropathyClient(getAuthClient());
        res.result = await client.calculateContrastInducedNephropathy(
            isHypotonia,
            isVABK,
            isNYHA,
            isOldAge,
            isAnemya,
            isDiabetes,
            isBigCreatinin,
            volumeContrast,
            speedKF
        );

    } catch (error) {
        res = {
            result: undefined,
            error: {
                errors: ["Непредвиденная ошибка"],
            },
        };
        return res;
    }

    return res;
}

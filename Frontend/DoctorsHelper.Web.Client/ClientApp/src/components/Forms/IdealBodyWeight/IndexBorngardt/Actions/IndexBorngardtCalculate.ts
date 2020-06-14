import {IResult, IErrors} from "../../../../../common/Interfaces";
import {BorngardtResponse, IdealBodyWeightClient} from "../../../../../apiClient/apiClient";
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function IndexBorngardtCalculate(
    height: number,
    chestСircumference: number
) {
    let res: IResult<BorngardtResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new IdealBodyWeightClient(getAuthClient());
        res.result = await client.calculateBorngardt(height, chestСircumference);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}

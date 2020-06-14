export class AuthClient {
    constructor(private apiUrl: string) {
    }

    getBaseUrl(defaultUrl: string, requestedUrl?: string) {
        return requestedUrl ? requestedUrl : this.apiUrl;
    }

    transformHttpRequestOptions(options: RequestInit): Promise<RequestInit> {
        return Promise.resolve(options);
    }
}

export class AccessTokenAuthClient extends AuthClient {
    constructor(apiUrl: string, private accessToken: string) {
        super(apiUrl);
    }

    transformHttpRequestOptions(options: RequestInit): Promise<RequestInit> {
        if (options.headers && this.accessToken) {
            options.headers = {...options.headers, Authorization:'Bearer ' + this.accessToken};
        }

        return super.transformHttpRequestOptions(options);
    }
}

export class ApiClientBase {
    constructor(private authClient: AuthClient) {

    }

    getBaseUrl(defaultUrl: string, requestedUrl?: string) {
        return this.authClient ? this.authClient.getBaseUrl(defaultUrl, requestedUrl) : defaultUrl;
    }

    transformOptions(options: RequestInit): Promise<RequestInit> {
        return this.authClient ? this.authClient.transformHttpRequestOptions(options) : Promise.resolve(options);
    }
}
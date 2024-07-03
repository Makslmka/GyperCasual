mergeInto(LibraryManager.library, {

	GetLang: function() {
		if (ysdk !== null){
			var lang = ysdk.environment.i18n.lang;
			var bufferSize = lengthBytesUTF8(lang) + 1;
			var buffer = _malloc(bufferSize);
			stringToUTF8(lang, buffer, bufferSize);
			return buffer;
		}
		else{
			return 'ru';
		}
	},
	
	GetUserData: function() {
		getUserData();
	},

	ShowFullscreenAd: function () {
		showFullscreenAd();
	},

	ShowRewardedAd: function(placement) {
		showRewardedAd(placement);
		return placement;
	},
	
	SendGameReadyApi: function () {
		GameReapyApi();
	},

});
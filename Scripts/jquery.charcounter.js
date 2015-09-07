/******************************************************************************************************

jQuery.NobleCount

Author Jeremy Horn
Version 1.0
Date: 3/21/2010

Copyright (c) 2010 Jeremy Horn- jeremydhorn(at)gmail(dot)c0m | http://tpgblog.com
Dual licensed under MIT and GPL.



******************************************************************************************************/

(function($) {


    $.fn.NobleCount = function(c_obj, options) {
        var c_settings;
        var mc_passed = false;

        // if c_obj is not specified, then nothing to do here
        if (typeof c_obj == 'string') {
            // check for new & valid options
            c_settings = $.extend({}, $.fn.NobleCount.settings, options);

            // was max_chars passed via options parameter? 
            if (typeof options != 'undefined') {
                mc_passed = ((typeof options.max_chars == 'number') ? true : false);
            }

            // process all provided objects
            return this.each(function() {
                var $this = $(this);

                // attach events to c_obj
                attach_nobility($this, c_obj, c_settings, mc_passed);
            });
        }

        return this;
    };


    $.fn.NobleCount.settings = {

        on_negative: null, 	// class (STRING) or FUNCTION that is applied/called 
        // 		when characters remaining is negative
        on_positive: null, 	// class (STRING) or FUNCTION that is applied/called 
        // 		when characters remaining is positive
        on_update: null, 	// FUNCTION that is called when characters remaining 
        // 		changes
        max_chars: 140, 		// maximum number of characters
        block_negative: false,  // if true, then all attempts are made to block entering 
        //		more than max_characters
        cloak: false, 		// if true, then no visual updates of characters 
        // 		remaining (c_obj) occur
        in_dom: false			// if true and cloak == true, then number of characters
        //		remaining are stored as the attribute
        //		'data-noblecount' of c_obj

    };


    /**********************************************************************************/

    function attach_nobility(t_obj, c_obj, c_settings, mc_passed) {
        var max_char = c_settings.max_chars;
        var char_area = $(c_obj);

        // first determine if max_char needs adjustment
        if (!mc_passed) {
            var tmp_num = char_area.text();
            var isPosNumber = (/^[1-9]\d*$/).test(tmp_num);

            if (isPosNumber) {
                max_char = tmp_num;
            }
        }



        // initialize display of characters remaining
        // * note: initializing should not trigger on_update
        event_internals(t_obj, char_area, c_settings, max_char, true);

        // then attach the events -- seem to work better than keypress
        $(t_obj).keydown(function(e) {
            event_internals(t_obj, char_area, c_settings, max_char, false);

            // to block text entry, return false
            if (check_block_negative(e, t_obj, c_settings, max_char) == false) {
                return false;
            }
        });

        $(t_obj).keyup(function(e) {
            event_internals(t_obj, char_area, c_settings, max_char, false);

            // to block text entry, return false
            if (check_block_negative(e, t_obj, c_settings, max_char) == false) {


                return false;
            }
        });
    }




    function check_block_negative(e, t_obj, c_settings, max_char) {
        if (c_settings.block_negative) {
            var char_code = e.which;
            var selected;

            // goofy handling required to work in both IE and FF
            if (typeof document.selection != 'undefined') {
                selected = (document.selection.createRange().text.length > 0);
            } else {
                selected = (t_obj[0].selectionStart != t_obj[0].selectionEnd);
            }

            //return false if can't write more
            var remaining = find_remaining(t_obj, max_char);
            if ((!((remaining < 1) &&
				(char_code > 47 || char_code == 32 || char_code == 0 || char_code == 13) &&
				!e.ctrlKey &&
				!e.altKey &&
				!selected)) == false) {

                // block text entry

                return false;
            }
        }

        // allow text entry
        return true;
    }




    function find_remaining(t_obj, max_char) {
        return max_char - ($(t_obj).val()).length;
    }




    /**********************************************************************************/

    function event_internals(t_obj, char_area, c_settings, max_char, init_disp) {
        var char_rem = find_remaining(t_obj, max_char);

        // is chararacters remaining positive or negative
        if (char_rem < 0) {
            toggle_states(c_settings.on_negative, c_settings.on_positive, t_obj, char_area, c_settings, char_rem);

            var txt = $(t_obj).val();
            txt = txt.substring(0, max_char);
            $(t_obj).val(txt);

        } else {
            toggle_states(c_settings.on_positive, c_settings.on_negative, t_obj, char_area, c_settings, char_rem);
        }

        // determine whether or not to update the text of the char_area (or c_obj)
        if (c_settings.cloak) {
            // this slows stuff down quite a bit; TODO: implement better method of publically accessible data storage
            if (c_settings.in_dom) {
                char_area.attr('data-noblecount', char_rem);
            }
        } else {
            // show the numbers of characters remaining 
            char_area.text(char_rem);
        }

        // if event_internals isn't being called for initialization purposes and
        // on_update is a properly defined function then call it on this update
        if (!init_disp && jQuery.isFunction(c_settings.on_update)) {
            c_settings.on_update(t_obj, char_area, c_settings, char_rem);
        }
    }


    /**********************************************************************************/



    function toggle_states(toggle_on, toggle_off, t_obj, char_area, c_settings, char_rem) {
        if (toggle_on != null) {
            if (typeof toggle_on == 'string') {
                char_area.addClass(toggle_on);
            } else if (jQuery.isFunction(toggle_on)) {
                toggle_on(t_obj, char_area, c_settings, char_rem);
            }
        }

        if (toggle_off != null) {
            if (typeof toggle_off == 'string') {
                char_area.removeClass(toggle_off);
            }
        }
    }
})(jQuery);
